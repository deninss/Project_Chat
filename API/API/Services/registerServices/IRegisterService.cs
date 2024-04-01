using API.Model;

namespace API.Services.registerServices
{
    public interface IRegisterService
    { 
        Task<bool> RegisterUser(RegisterUser user);
    }
}