using Microsoft.AspNetCore.SignalR;
using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Hubs
{
    public class ChatHub : Hub
    {
        private readonly string _botUser;
        public ChatHub()
        {
            _botUser = "MyChat Bot";
        }
        public async Task SendMessage(AllMessagesModel msg)
        {   
            await Clients.Group(msg.groupId.ToString()).SendAsync("ReceiveMessage", msg); 
        }

        public async Task JoinRoom(UserConnection userConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.room);
            //await Clients.Group(userConnection.room).SendAsync("ReceiveMessage", _botUser, 
            //    $"{userConnection.user} has joined {userConnection.room}");
        }   
    }
}
