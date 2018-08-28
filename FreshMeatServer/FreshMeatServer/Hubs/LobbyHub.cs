using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace FreshMeatServer.Hubs
{
    [Authorize(Policy = "ApiUser")]
    public class LobbyHub: Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public Task SendMessageToCaller(string message)
        {
            return Clients.Caller.SendAsync("ReceiveMessage", message);
        }

        public Task SendMessageToGroups(string strMatchId, string message)
        {
            List<string> groups = new List<string>() { strMatchId };
            return Clients.Groups(groups).SendAsync("ReceiveMessage", message);
        }

        public async Task AddUserToLobby(string strMatchId, string connectionId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, strMatchId);
        }        

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnDisconnectedAsync(exception);
        }
    }
}
