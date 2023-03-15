using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace ZombieServer
{
    public class ZombieServer
    {
        
        private static byte[] buffer = new byte[512];
        public static void StartServer()
        {
            //private int PlayerCount = 3;
            int PlayerCount = 3;
        IPAddress ip = IPAddress.Parse("127.0.0.1");
            Console.WriteLine("Server name: {0}", ip);
            IPEndPoint localEP = new IPEndPoint(ip, 8889);

            Socket server = new Socket(ip.AddressFamily, SocketType.Dgram, ProtocolType.Udp);

            EndPoint fromClient = new IPEndPoint(IPAddress.Any, 0);

            try
            {
                server.Bind(localEP);

                Console.WriteLine("Waiting for connection");
                int rec = server.ReceiveFrom(buffer, ref fromClient);

                Console.WriteLine("Connection Done... from: " + rec.ToString());

                //Send + 1 to client to know how many players for now send 3
                //Write Code to send only 1 for each client connected
                Console.WriteLine("Sending Player Count");
                buffer = Encoding.ASCII.GetBytes(PlayerCount.ToString());
                server.SendTo(buffer, localEP);
                Console.WriteLine("Waiting Responds...");
                rec = server.ReceiveFrom(buffer, ref fromClient);
                Console.WriteLine(rec.ToString());

                
                //Console.WriteLine("Player Count: " + PlayerCount + " has been sent");
                //do
                //{
                    // Do movement of players using array of floats[]
                    // Already got an idea how to send position
                    // Need to work on sending it to all clients but 
                    // not the client that sends the data
                //} while (true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static int Main(String[] args)
        {
            StartServer();
            return 0;
        }
    }
}
