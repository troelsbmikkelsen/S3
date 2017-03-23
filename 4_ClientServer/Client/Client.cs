using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client {
    class Client {
        static void Main(string[] args) {
            int port = 1234;
            using (TcpClient client = new TcpClient("localhost", port))
            using (NetworkStream stream = client.GetStream())
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true }) {
                try {
                    Console.Write("Enter your username: ");
                    string username = Console.ReadLine();
                    writer.WriteLine(username);
                    Console.WriteLine(reader.ReadLine());
                    string message = "";

                    Task.Run(() => {
                        while (true) {
                            message = reader.ReadLine();
                            if (message != null && message != "") {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine(message);
                                Console.ForegroundColor = ConsoleColor.Green;
                            } else {
                                return;
                            }
                        }
                    });

                    while (true) {
                        Console.ForegroundColor = ConsoleColor.Green;
                        string toSend = Console.ReadLine();
                        
                        if (toSend == "exit" || toSend == "logout") {
                            writer.WriteLine($"{username} has left the chat");
                            return;
                        }
                        writer.WriteLine(toSend);
                    }
                } catch (Exception e) {
                    Console.WriteLine("Server refused connection.");
                    Console.WriteLine(e.Message);
                    return;
                }
                
            }
        }
    }
}
