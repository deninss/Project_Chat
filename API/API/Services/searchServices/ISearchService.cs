using API.Model;

namespace API.Services.searchServices
{
    public interface ISearchService
    {
        Task<IEnumerable<Chats>> SearchUserAsync(string query);
        Task<IEnumerable<Chats>> SearchGroupAsync(string query);
    }
}
