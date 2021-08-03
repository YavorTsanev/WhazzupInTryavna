namespace WhazzupInTryavna.Web.Hubs
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.SignalR;
    using WhazzupInTryavna.Web.ViewModels.Chat;

    [Authorize]
    public class ChatHub : Hub
    {
        private static readonly List<string> Users = new();

        public async Task Send(string message)
        {
            await this.Clients.All.SendAsync(
                "NewMessage",
                new Message { User = this.Context.User.Identity.Name, Text = message });
        }

        public override Task OnConnectedAsync()
        {
            var username = this.GetUsername();
            if (!Users.Contains(username))
            {
                Users.Add(username);
            }

            this.Clients.All.SendAsync("updateUsers", Users);
            return Task.CompletedTask;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var username = this.GetUsername();

            if (Users.Contains(username))
            {
                Users.Remove(username);
            }

            this.Clients.All.SendAsync("updateUsers", Users);
            return Task.CompletedTask;
        }

        private string GetUsername()
        {
            return this.Context.User.Identity.Name;
        }
    }
}
