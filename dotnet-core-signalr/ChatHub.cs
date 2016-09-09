using Microsoft.AspNetCore.SignalR;

namespace ConsoleApplication
{
    public class ChatHub : Hub
    {
        public void Send(string message)
        {
            Clients.All.display(message);
        }
    }
}