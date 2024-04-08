using API.Model;

namespace API.Services.searchServices
{
    public interface ISearchService
    {
        Task<List<Chats>> SearchUserAsync(string query);
        Task<List<Chats>> SearchGroupAsync(string query);
    }
}
