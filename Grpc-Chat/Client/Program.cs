using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Server.Protos;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Text;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // var channel = GrpcChannel.ForAddress("https://localhost:5001");
            // var client = new Connect.ConnectClient(channel);

            // Console.WriteLine("Please type in your name:");
            // string name = Console.ReadLine();

            // var username = new ConnectedRequest { Username = name };
            // var reply = await client.SendUsernameAsync(username);
            // Console.WriteLine(reply.ConnectedConfirmation);
            //// Console.ReadLine();
            // Socket clientSocket = new Socket(AddressFamily
            //     .InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // while (true)
            // {
            //     string messageFromClient = null;
            //     Console.WriteLine("Enter the message");
            //     messageFromClient = Console.ReadLine();
            //     byte[] MsgFromServer = new byte[1024];
            // }

            //var channel = GrpcChannel.ForAddress("https://localhost:5001");
            //var Client = new Connect.ConnectClient(channel);
            Console.WriteLine("Please type in your name:");
            string name = Console.ReadLine();
            //var username = new ConnectedRequest { Username = name };           
            //var reply = await Client.SendUsernameAsync(username);
            //Console.WriteLine(reply.ConnectedConfirmation);

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            int port = 5000;
            TcpClient client = new TcpClient();
            client.Connect(ip, port);
            Console.WriteLine("client connected!!");
            NetworkStream ns = client.GetStream();
            Thread thread = new Thread(o => ReceiveData((TcpClient)o));
            thread.Start(client);

            string s;
            Console.WriteLine("Send a message:");
            while (!string.IsNullOrEmpty((s = Console.ReadLine())))
            {
                Console.WriteLine("Send a message:");
                byte[] buffer = Encoding.ASCII.GetBytes(s);
                ns.Write(buffer, 0, buffer.Length);
            }

            client.Client.Shutdown(SocketShutdown.Send);
            thread.Join();
            ns.Close();
            client.Close();
            Console.WriteLine("disconnect from server!!");
            Console.ReadKey();
        }

      
}
