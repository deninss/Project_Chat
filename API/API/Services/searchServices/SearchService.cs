using API.Model;

namespace API.Services.searchServices
{
    public class SearchService : ISearchService
    {
        public async Task<List<Chats>> SearchUserAsync(string query)
        {
            // Add your search logic here
            return await Task.FromResult(new List<Chats>());
        }
        public async Task<List<Chats>> SearchGroupAsync(string query)
        {
            // Add your search logic here
            return await Task.FromResult(new List<Chats>());
        }
    }
}
