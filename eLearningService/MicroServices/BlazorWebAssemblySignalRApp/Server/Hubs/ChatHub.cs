using Microsoft.AspNetCore.SignalR;

namespace BlazorWebAssemblySignalRApp.Server.Hubs{
    public class ChatHub : Hub{
        public async Task Sendmessage(string user, string message){
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}