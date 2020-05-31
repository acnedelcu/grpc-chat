using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Server.Protos;
using System.Net.Sockets;
using System.Net;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Connect.ConnectClient(channel);

            Console.WriteLine("Please type in your name:");
            string name = Console.ReadLine();

            var username = new ConnectedRequest { Username = name };
            var reply = await client.SendUsernameAsync(username);
            Console.WriteLine(reply.ConnectedConfirmation);
           // Console.ReadLine();
            Socket clientSocket = new Socket(AddressFamily
                .InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            while (true)
            {
                string messageFromClient = null;
                Console.WriteLine("Enter the message");
                messageFromClient = Console.ReadLine();
                byte[] MsgFromServer = new byte[1024];
            }

        }
    }
}
