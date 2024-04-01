using Microsoft.AspNetCore.Identity;

namespace API.Context
{
    public class _IdentityUsers : IdentityUser
    {
        public string? Name { get; set; } 
        public string? Surname { get; set; } 
        public string? Patronymic { get; set; }
    }
}
