using API.Context;
using API.Model;
using API.Services.registerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services.loginServices
{
    public class LoginService : ILoginService
    {
        private readonly UserManager<_IdentityUsers> _userManager;
        private readonly SignInManager<_IdentityUsers> _signInManager;
        private readonly IConfiguration _config;
        public LoginService(UserManager<_IdentityUsers> userManager, IConfiguration config, SignInManager<_IdentityUsers> signInManager)
        {
            _userManager = userManager;
            _config = config;
            _signInManager = signInManager;
        }
        public async Task<bool> Login(LoginUser user)
        {
            //var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, lockoutOnFailure: false);

            var identityUser = await _userManager.FindByEmailAsync(user.Email);
            var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return await _userManager.CheckPasswordAsync(identityUser, user.Password); ;
            }

            return false;
        }
        public string GenerateTokenString(LoginUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,"Admin"),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value.PadRight(64))); 

            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                issuer: _config.GetSection("Jwt:Issuer").Value,
                audience: _config.GetSection("Jwt:Audience").Value,
                signingCredentials: signingCred);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return tokenString;
        }

    }
}
