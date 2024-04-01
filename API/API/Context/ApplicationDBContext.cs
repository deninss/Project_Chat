using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public class ApplicationDBContext : IdentityDbContext<_IdentityUsers>
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }
    }
}
