using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chats.Services
{
    public class ApiSService 
    {
        private HubConnection _hubConnection;
        public async Task Connect()
        {
            _hubConnection = new HubConnectionBuilder().WithUrl("http://10.0.2.2:5117/hubController").Build();
            await ConnectAsync();
        }
        public async Task ConnectAsync()
        {
            // Убедимся что подключение запущено
            if (_hubConnection.State == HubConnectionState.Disconnected) await _hubConnection.StartAsync();
        }
         
        public async Task Search(string messages, string type)
        {
            await ConnectAsync();
            if(type == "User")
            {
                await _hubConnection.InvokeAsync("SearchUser", messages);
                _hubConnection.On<string>("SearchResultsUser", result =>
                {
                 
                });
            }
            if (type == "Group")
            {
                await _hubConnection.InvokeAsync("SearchGroup", messages);
                _hubConnection.On<string>("SearchResultsGroup", result =>
                {

                });
            }
        }
    }
}
