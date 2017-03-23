using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerAsync {
    class ServerAsync {
        static void Main(string[] args) {
            Task.Run(async () => {
                int port = 1234;
                TcpListener listener = new TcpListener(IPAddress.Loopback, port);
                listener.Start();

                while (true) {
                    TcpClient client = await listener.AcceptTcpClientAsync().ConfigureAwait(false);

                    HandleClient(client);
                }
            }).GetAwaiter().GetResult();
        }

        static void HandleClient(TcpClient client) {
            using (NetworkStream stream = client.GetStream())
            using (StreamWriter writer = new StreamWriter(stream, Encoding.ASCII) { AutoFlush = true })
            using (StreamReader reader = new StreamReader(stream, Encoding.ASCII)) {
                while (true) {
                    string input = "";
                    while (input != null) {
                        try {
                            input = reader.ReadLine();
                            writer.WriteLine("Echoing string: " + input);
                            Console.WriteLine("Echoing string: " + input);
                        } catch (Exception e) {
                            Console.WriteLine("User disconnected");
                            client.Close();
                            return;
                        }
                    }
                }
            }
        }
    }
}
