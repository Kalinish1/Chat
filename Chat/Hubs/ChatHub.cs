using Microsoft.AspNetCore.SignalR;

namespace ChatServer.Hubs
{
	public class ChatHub : Hub
	{
		//sending notifications to all clients in this hub
		// <SendMessage()> to communicate and <ReceiveMessage> to recieve notifications
		public async Task SendMessage(string message, string user)
		{
			await Clients.All.SendAsync("RecieveMessage", message, user);
		}

		public async Task JoinChatNotification(string user, string message)
		{
			await Clients.Others.SendAsync("RecieveMessage", message, user);
		}
		public override async Task OnConnectedAsync()
		{
			await Clients.All.SendAsync("RecieveMessage", $"{Context.ConnectionId} has joined");
		}
	}
}
