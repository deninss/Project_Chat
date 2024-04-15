using API.Context;
using API.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Services.searchServices
{
    public class SearchService : ISearchService
    {
        private readonly UserManager<_IdentityUsers> _userManager;
        public SearchService(UserManager<_IdentityUsers> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IEnumerable<Chats>> SearchUserAsync(string query)
        { 
            var results = await _userManager.Users.Where(x => EF.Functions.Like(x.UserName, $"%{query}%")).Select(x => new Chats { Id = x.Id, Name = x.UserName }).ToListAsync();
            return results;
        }
        public async Task<IEnumerable<Chats>> SearchGroupAsync(string query)
        {

            // Add your search logic here
            return await Task.FromResult(new List<Chats>());
        }
    }
}
