namespace Orm.Data
{
    using Models.Models;
    using System.Data.Entity;

    public class GameContext : DbContext
    {
        public GameContext()
            : base("name=GameContext")
        {
        }

        public virtual DbSet<User> ApplicationUsers { get; set; }

        public virtual DbSet<Player> GameUsers { get; set; }

        public virtual DbSet<Map> Maps { get; set; }

        public virtual DbSet<SpawnPoint> SpawnPoints { get; set; }

        public virtual DbSet<CheckPoint> CheckPoints { get; set; }

        public virtual DbSet<Collectable> Collectables { get; set; }
    }
}