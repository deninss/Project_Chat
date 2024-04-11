using Chats.Model;
using Chats.ViewModel._login;
using Chats.ViewModel._register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Chats.Services
{
    public interface IApiRService
    {
        Task<bool> LoginAsync(LoginModel loginModel);
        Task<bool> RegisterAsync(RegisterModel loginModel);
        Task<bool> ListChatsAsync(ListChat listChat);
    }
}
