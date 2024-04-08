using API.Services.searchServices;
using Microsoft.AspNetCore.SignalR;

namespace API.HubController
{
    public class hubController : Hub
    {
        protected ISearchService _searchService { get; }

        public hubController(ISearchService searchService)
        {
            _searchService = searchService;
        }
        public async Task SearchUser(string query)
        {
            var results = await _searchService.SearchUserAsync(query);
            await Clients.Caller.SendAsync("SearchResultsUser", results);
        }
        public async Task SearchGroup(string query)
        {
            var results = await _searchService.SearchGroupAsync(query);
            await Clients.Caller.SendAsync("SearchResultsGroup", results);
        }
    }
}
