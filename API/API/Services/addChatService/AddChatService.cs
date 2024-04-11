using API.Context;
using API.Model;

namespace API.Services.addChatService
{
    public class AddChatService : IAddChatService
    {
        public ApplicationDBContext dBContext { get; set; }
        public Task<IEnumerable<ListChat.PChat>> AddChatAsync(string idUser1, string idUser2)
        {
            dBContext.Add(idUser1);
            dBContext.Add(idUser2);
            dBContext.SaveChanges();
            return null;
        }
    }
}
