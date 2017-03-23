using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ServerLogger;

namespace Server {
    class Server {
        // Log
        static Logger logger = new Logger();
        
        // List to contain all allowed users
        static List<string> allowedUsers = new List<string>();
        static ConcurrentQueue<KeyValuePair<string, string>> messages = new ConcurrentQueue<KeyValuePair<string, string>>();

        static Dictionary<string, TcpClient> connectedUsers = new Dictionary<string, TcpClient>();

        static void Main(string[] args) {
            // Read allowed users file
            allowedUsers = File.ReadAllLines("users").ToList();

            // Write out allowed users
            foreach (string user in allowedUsers) {
                Console.WriteLine(user);
            }
            
            int port = 1234;
            // Listen on the loopback address / localhost
            TcpListener listener = new TcpListener(IPAddress.Any, port);
            listener.Start();

            // As this is a server, we need to always be ready to accept new clients.
            // We do this by running an infinite loop, accepting new clients as they try to connect.
            // When they connect, we spin up a task to handle that client, and go back to listening for connections.
            while (true) {
                // Accept client
                TcpClient client = listener.AcceptTcpClient();
                // Spin up task on the threadpool
                Task.Run(() => HandleClient(client));
            }
        }

        static void HandleClient(TcpClient client) {
            // Using statements make sure that the objects created in the parenthesis are properly disposed of.
            using (NetworkStream stream = client.GetStream())
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true })
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8)) {
                // Simple user authentication
                string username = reader.ReadLine();
                // If the user exists in allowed users and is not already connected
                if (allowedUsers.Any(au => au == username && !connectedUsers.Any(cu => cu.Key == username))) {
                    // Welcome them and add username to connected users
                    Console.WriteLine($"{username} has connected");
                    logger.Log($"{username} has connected");

                    writer.WriteLine($"Welcome, {username}");
                    connectedUsers.Add(username, client);
                } else {
                    // Disconnect them
                    Console.WriteLine($"{username}, tried to connect but was denied");
                    logger.Log($"{username}, tried to connect but was denied");
                    writer.WriteLine("Username not accepted, or already connected");
                    return;
                }

                while (true) {
                    string input = "";
                    while (input != null) {
                        try {
                            input = reader.ReadLine();

                            if (input == "exit" || input == "logout") {
                                client.GetStream().Close();
                                client.Close();
                                connectedUsers.Remove(username);
                            }
                            
                            messages.Enqueue(new KeyValuePair<string, string>(username, input));

                            // Write message to all connected clients
                            StreamWriter remoteWriter;
                            foreach(KeyValuePair<string, TcpClient> user in connectedUsers) {
                                if(user.Key != username) {
                                    remoteWriter = new StreamWriter(user.Value.GetStream());
                                    remoteWriter.WriteLine($"{username}: {input}");
                                    remoteWriter.Flush();
                                }
                            }
                            Console.WriteLine($"{username} wrote: {input}");
                            logger.Log($"{username} wrote: {input}");
                        } catch (Exception e) {
                            Console.WriteLine($"{username} disconnected");
                            client.GetStream().Close();
                            client.Close();
                            connectedUsers.Remove(username);
                            return;
                        }
                    }
                }
            }
        }
    }
}
