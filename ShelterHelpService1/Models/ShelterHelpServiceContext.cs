using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ShelterHelpService1.Models
{
    public class ShelterHelpServiceContext : IdentityDbContext<UserEntity>
    {
        public ShelterHelpServiceContext(DbContextOptions<ShelterHelpServiceContext> dbo) : base(dbo) { }

        public DbSet<TimelinePost> TimelinePostTable { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserEntity>()
                .HasMany(user => user.TimelinePosts)
                .WithOne(tlp => tlp.Author);

            builder.Entity<TimelinePost>()
                .HasOne(tlp => tlp.Author)
                .WithMany(user => user.TimelinePosts);
        }
    }
}
