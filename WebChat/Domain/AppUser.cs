using Microsoft.AspNetCore.Identity;

namespace WebChat.Domain
{
    public class AppUser : IdentityUser
    {
        [PersonalData]
        public string? Name { get; set; }
        [PersonalData]
        public string? Surname { get; set; }
        [PersonalData]
        public string? Patronymic { get; set; }
    }

}
