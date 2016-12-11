namespace Teh_te4_tekh_ORM.Controllers
{
    using System.Data.Entity;

    using Models;

    public class GameContext : DbContext
    {
        public GameContext()
            : base("name=GameContext")
        {
        }

        public DbSet<User> ApplicationUsers { get; set; }

        public DbSet<Player> GameUsers { get; set; }

        public DbSet<Map> Maps { get; set; }

        public DbSet<SpawnPoint> SpawnPoints { get; set; }

        public DbSet<CheckPoint> CheckPoints { get; set; }

        public DbSet<Collectable> Collectables { get; set; }
    }
}