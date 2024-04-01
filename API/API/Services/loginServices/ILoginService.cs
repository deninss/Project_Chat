using API.Model;

namespace API.Services.loginServices
{
    public interface ILoginService
    {
        string GenerateTokenString(LoginUser user);
        Task<bool> Login(LoginUser user); 
    }
}
