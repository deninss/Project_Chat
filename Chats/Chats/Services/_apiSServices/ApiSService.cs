using Chats.Model;
using Chats.ViewModel._personChat;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Chats.Services
{
    public class ApiSService
    {
        private HubConnection _hubConnection;
        //public ObservableCollection<Search> search { get; set; }
        private PersonChatViewModel _viewModel;

        public ApiSService(PersonChatViewModel viewModel)
        {
            _viewModel = viewModel;
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("http://10.0.2.2:5117/hubContext")
                .Build();

            _hubConnection.On<string>("SearchResultsUser", (result) =>
            {
                var dataObject = JsonConvert.DeserializeObject<IEnumerable<Search>>(result);
                _viewModel.SearchResults.Clear();
                foreach (var model in dataObject)
                {
                    _viewModel.SearchResults.Add(model);
                }
            });
            _hubConnection.On<string>("SearchResultsGroup", (result) =>
            {
                var dataObject = JsonConvert.DeserializeObject<IEnumerable<Search>>(result);
                _viewModel.SearchResults.Clear();
                foreach (var model in dataObject)
                {
                    _viewModel.SearchResults.Add(model);
                }
            });
        }

        public async Task Connect() => await _hubConnection.StartAsync();
        public async Task Disconnect() => await _hubConnection.StopAsync();

        public async Task Search(string message, string type)
        {
            if (type == "User") await _hubConnection.InvokeAsync("SearchUser", message);
            else if (type == "Group") await _hubConnection.InvokeAsync("SearchGroup", message);
        }
        public async Task AddChat(string idUser)
        { 
            await _hubConnection.InvokeAsync("AddPersonChat", idUser, "945c2ef8-781d-43ba-a016-b283049b3de2");
        }
    }
}
