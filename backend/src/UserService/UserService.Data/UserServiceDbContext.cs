
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserService.Domain.Models;

namespace UserService.Infrastructure
{
    public class UserServiceDbContext : IdentityDbContext<User, Role, Guid>
    {
        public UserServiceDbContext(DbContextOptions<UserServiceDbContext> options)
           : base(options)
        {
        }
    }
}
