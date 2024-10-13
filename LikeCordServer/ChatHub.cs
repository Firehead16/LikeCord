using Microsoft.AspNetCore.SignalR;

namespace LikeCordServer
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            try
            {
                await Clients.All.SendAsync("ReceiveMessage", user, message);
                Console.WriteLine("ReceiveMessage " + user + " : " + message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending message: {ex.Message}");
                // Также можно отправить сообщение о неудаче обратно клиенту, если это нужно
            }
        }
    }
}
