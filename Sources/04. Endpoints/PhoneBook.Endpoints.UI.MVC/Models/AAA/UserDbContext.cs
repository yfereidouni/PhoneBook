using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PhoneBook.Endpoints.UI.MVC.Models.AAA
{
    public class UserDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<BadPasswords> BadPasswords { get; set; }

        public UserDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BadPasswords>().HasKey(c => c.Id);

            builder.Entity<BadPasswords>()
                .HasData(new BadPasswords { Id = 1, Password = "123" });

            builder.Entity<BadPasswords>()
                .HasData(new BadPasswords { Id = 2, Password = "123456" });

            builder.Entity<BadPasswords>()
                .HasData(new BadPasswords { Id = 3, Password = "123456789" });

            builder.Entity<BadPasswords>()
                .HasData(new BadPasswords { Id = 4, Password = "0123456789" });

            builder.Entity<BadPasswords>()
                .HasData(new BadPasswords { Id = 5, Password = "1234567890" });

            builder.Entity<BadPasswords>()
                .HasData(new BadPasswords { Id = 6, Password = "AAA" });

            builder.Entity<BadPasswords>()
                .HasData(new BadPasswords { Id = 7, Password = "BBB" });

            builder.Entity<BadPasswords>()
                .HasData(new BadPasswords { Id = 8, Password = "CCC" });

            builder.Entity<BadPasswords>()
                .HasData(new BadPasswords { Id = 9, Password = "ABC" });

            base.OnModelCreating(builder);
        }
    }
}


