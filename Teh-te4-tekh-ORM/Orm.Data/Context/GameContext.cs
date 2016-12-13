namespace Orm.Data.Context
{
    using Models.Models;
    using System.Data.Entity;

    public class GameContext : DbContext
    {
        public GameContext()
            : base("name=GameContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Player> Players { get; set; }

        public virtual DbSet<Map> Maps { get; set; }

        public virtual DbSet<SpawnPoint> SpawnPoints { get; set; }

        public virtual DbSet<CheckPoint> CheckPoints { get; set; }

        public virtual DbSet<Collectable> Collectables { get; set; }
    }
}