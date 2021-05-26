using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ShelterHelpService1.Models
{
    public class ShelterHelpServiceContext : IdentityDbContext<User>
    {
        public ShelterHelpServiceContext(DbContextOptions<ShelterHelpServiceContext> dbo) : base(dbo) { }
    }
}
