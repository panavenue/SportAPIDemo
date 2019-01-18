using Microsoft.EntityFrameworkCore;

namespace SportApi.Models
{
    public class SportContext : DbContext
    {
        public SportContext(DbContextOptions<SportContext> options)
            : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameState> GameStates { get; set; }
        public DbSet<PlayerStat> PlayerStats { get; set; }
    }
}