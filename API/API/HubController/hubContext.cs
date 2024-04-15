 
using API.Model;
using API.Services.addChatService;
using API.Services.searchServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API.HubController
{
    [Authorize]
    public class hubContext : Hub
    {

        protected ISearchService _searchService { get; }
        protected IAddChatService _addChatService { get; }
        private readonly ILogger<hubContext> _logger;

        public hubContext(ISearchService searchService, ILogger<hubContext> logger)
        {
            _searchService = searchService;
            _logger = logger;
        }
        public async Task SearchUser(string query )
        {
            var userId = Context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userName = Context.User.Identity.Name;
            _logger.LogInformation("Поиск пользователя: {Query}", query);
            try
            {
                var results = await _searchService.SearchUserAsync(query);
                var jsonData = JsonConvert.SerializeObject(results);
                await Clients.Client(Context.ConnectionId).SendAsync("SearchResultsUser", jsonData);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Ошибка при поиске пользователя: {Query}", query); 
            }
            await base.OnConnectedAsync();
        }
        public async Task SearchGroup(string query)
        { 
            _logger.LogInformation("Поиск пользователя: {Query}", query);
            try
            {
                var results = await _searchService.SearchGroupAsync(query);
                var jsonData = JsonConvert.SerializeObject(results);
                await Clients.Caller.SendAsync("SearchResultsGroup", jsonData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при поиске пользователя: {Query}", query);
                // Обработка исключения
            }
            await base.OnConnectedAsync();
        }
        public async Task AddPersonChat(string idUser1, string idUser2)
        {
            var results = await _addChatService.AddChatAsync(idUser1, idUser2);
            await Clients.Caller.SendAsync("SearchResultsGroup", results);
        }
    }
}
