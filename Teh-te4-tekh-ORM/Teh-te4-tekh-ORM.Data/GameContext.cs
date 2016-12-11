using Teh_te4_tekh_ORM.Models;

namespace Teh_te4_tekh_ORM.Controllers
{
    using System.Data.Entity;

    public class GameContext : DbContext
    {
        public GameContext()
            : base("name=GameContext")
        {
        }

        public DbSet<User> ApplicationUsers { get; set; }
        public DbSet<Player> GameUsers { get; set; }
        public DbSet<Map> Maps { get; set; }
    }
}