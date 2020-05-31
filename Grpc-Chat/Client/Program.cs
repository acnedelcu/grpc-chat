using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Server.Protos;

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
            Console.ReadLine();

        }
    }
}
