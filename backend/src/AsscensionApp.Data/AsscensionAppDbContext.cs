using Microsoft.EntityFrameworkCore;

namespace AsscensionApp.Data
{
    public class AsscensionAppDbContext : DbContext
    {
        public AsscensionAppDbContext(DbContextOptions<AsscensionAppDbContext> options)
           : base(options)
        {
        }
    }
}
