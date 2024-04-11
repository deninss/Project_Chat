using API.Model;

namespace API.Services.addChatService
{
    public interface IAddChatService
    {
        Task<IEnumerable<ListChat.PChat>> AddChatAsync(string idUser1, string idUser2);
    }
}
