using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ShelterHelpService1.Models
{
    public class ShelterHelpServiceContext : IdentityDbContext<UserTable>
    {
        public ShelterHelpServiceContext(DbContextOptions<ShelterHelpServiceContext> dbo) : base(dbo) { }

        public DbSet<CorrespondenceTable> СorrespondenceTable { get; set; }

        public DbSet<TimelinePostTable> TimelinePostTables { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CorrespondenceTable>().HasNoKey();
            builder.Entity<TimelinePostTable>().HasNoKey();

            base.OnModelCreating(builder);
        }
    }
}
