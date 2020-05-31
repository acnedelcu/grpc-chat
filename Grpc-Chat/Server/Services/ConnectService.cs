using System;
using System.Threading.Tasks;
using Grpc.Core;
using Server.Protos;

namespace Server
{
    public class ConnectService:Connect.ConnectBase
    {
        public ConnectService()
        {

        }
        public override Task<Confirmation> SendUsername(ConnectedRequest request, ServerCallContext context)
        {
            Console.WriteLine("User "+request.Username+" has connected!");

            Confirmation confirmationMessage = new Confirmation();
            string messageToSend= "You have sucessfully connected to the server!";
            confirmationMessage.ConnectedConfirmation = messageToSend;
            return Task.FromResult(confirmationMessage);
        }
    }
}
