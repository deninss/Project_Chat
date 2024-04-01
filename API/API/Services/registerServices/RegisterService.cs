using API.Context;
using API.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services.registerServices
{
    public class RegisterService : IRegisterService
    {
        private readonly IConfiguration _config;
        private readonly SignInManager<_IdentityUsers> _signInManager;
        private readonly UserManager<_IdentityUsers> _userManager;
        private readonly IUserStore<_IdentityUsers> _userStore;
        private readonly IUserEmailStore<_IdentityUsers> _emailStore;
        private readonly ILogger<RegisterService> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterService(UserManager<_IdentityUsers> userManager, IUserStore<_IdentityUsers> userStore,
            SignInManager<_IdentityUsers> signInManager, ILogger<RegisterService> logger, IEmailSender emailSender, IConfiguration config)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _config = config;
        }


        public async Task<bool> RegisterUser(RegisterUser user)
        {
            var users = Activator.CreateInstance<_IdentityUsers>();
            users.UserName = user.Email;
            users.Name = user.Name;
            users.Surname = user.Surname;
            users.Patronymic = user.Patronymic;
            users.Email = user.Email;
            var result = await _userManager.CreateAsync(users, user.Password);

            if (result.Succeeded)
            {
                // Log success or other information if needed
                _logger.LogInformation("User created successfully.");

                if (_userManager.Options.SignIn.RequireConfirmedAccount)
                {
                    return true;
                }
                else
                {
                    // Additional logic if account confirmation is not required
                    await _signInManager.SignInAsync(users, isPersistent: false);
                    return true;
                }
            }
            else
            {
                // Log errors for debugging
                foreach (var error in result.Errors)
                {
                    _logger.LogError($"Error in user creation: {error.Code} - {error.Description}");
                }
            }

            return false;
        }
       
        private _IdentityUsers CreateUser()
        {
            try
            {
                return Activator.CreateInstance<_IdentityUsers>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(_IdentityUsers)}'. " +
                    $"Ensure that '{nameof(_IdentityUsers)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
        private IUserEmailStore<_IdentityUsers> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<_IdentityUsers>)_userStore;
        }

       
    }
}
