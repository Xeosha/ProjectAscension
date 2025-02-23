
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UserService.Domain.Models;

namespace UserService.Infrastructure
{
    public class UserServiceDbContext(IConfiguration configuration)
        : IdentityDbContext<User, Role, Guid>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("UserServiceDbContext"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .ToTable("users");

            modelBuilder.Entity<Role>()
                .ToTable("roles");

            modelBuilder.Entity<IdentityUserClaim<Guid>>()
                .ToTable("user_claims");

            modelBuilder.Entity<IdentityUserToken<Guid>>()
                .ToTable("user_tokens");

            modelBuilder.Entity<IdentityUserLogin<Guid>>()
                .ToTable("user_logins");

            modelBuilder.Entity<IdentityRoleClaim<Guid>>()
                .ToTable("role_claims");

            modelBuilder.Entity<IdentityUserRole<Guid>>()
                .ToTable("user_roles");
        }
    }
}
