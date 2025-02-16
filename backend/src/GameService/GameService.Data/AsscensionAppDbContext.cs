using Microsoft.EntityFrameworkCore;

namespace GameService.Data
{
    public class GameServiceDbContext : DbContext
    {
        public GameServiceDbContext(DbContextOptions<GameServiceDbContext> options)
           : base(options)
        {
        }
    }
}
