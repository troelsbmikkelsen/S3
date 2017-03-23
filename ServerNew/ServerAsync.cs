using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerNew {
    class ServerAsync {
        // List to contain all allowed users
        static List<string> allowedUsers = new List<string>();
        static Queue<KeyValuePair<string, string>> messages = new Queue<KeyValuePair<string, string>>();

        static Dictionary<string, TcpClient> connectedUsers = new Dictionary<string, TcpClient>();

        static void Main(string[] args) {
            // Read allowed users file
            allowedUsers = File.ReadAllLines("users").ToList();

            // Write out allowed users
            foreach (string user in allowedUsers) {
                Console.WriteLine(user);
            }

            int port = 1234;
            // Listin on the loopback address / localhost
            TcpListener listener = new TcpListener(IPAddress.Loopback, port);
            listener.Start();

            // As this is a server, we need to always be ready to accept new clients.
            // We do this by running an infinite loop, checking for pending requests.
            // If there is a pending request, run a task to handle that request.
            while (true) {
                // If there is a pending connection request, handle
                if (listener.Pending()) {
                    Task.Run(() => HandleConnectionRequest(listener.AcceptTcpClient()));
                }
                // Check if any clients have disconnected
                for (int i = connectedUsers.Count - 1; i >= 0; i--) {
                    if (IsClientDisconnected(connectedUsers.ElementAt(i).Value)) {
                        connectedUsers.ElementAt(i).Value.GetStream().Close();
                        connectedUsers.ElementAt(i).Value.Close();
                        connectedUsers.Remove(connectedUsers.ElementAt(i).Key);
                    }
                }
            }
        }

        static void HandleConnectionRequest(TcpClient client) {
            using (NetworkStream stream = client.GetStream())
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true })
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8)) {
                // Simple user authentication
                string username = reader.ReadLine();
                // If the user exists in allowed users and is not already connected
                if (allowedUsers.Any(au => au == username && !connectedUsers.Any(cu => cu.Key == username))) {
                    // Welcome them and add username to connected users
                    Console.WriteLine($"{username} has connected");
                    writer.WriteLine($"Welcome, {username}");
                    connectedUsers.Add(username, client);
                } else {
                    // Disconnect them
                    Console.WriteLine($"{username}, tried to connect but was denied");
                    writer.WriteLine("Username not accepted, or already connected");
                    return;
                }
            }
        }

        static bool IsClientDisconnected(TcpClient client) {
            try {
                Socket s = client.Client;
                return (s.Available == 0) && s.Poll(10000, SelectMode.SelectRead);
            } catch (SocketException se) {
                return true;
            }
        }
    }
}
