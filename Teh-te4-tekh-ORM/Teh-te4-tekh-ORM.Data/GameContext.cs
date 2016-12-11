using Teh_te4_tekh_ORM.Models;

namespace Teh_te4_tekh_ORM.Controllers
{
    using System.Data.Entity;

    public class GameContext : DbContext
    {
        // Your context has been configured to use a 'GameContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Teh_te4_tekh_ORM.Controllers.GameContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'GameContext' 
        // connection string in the application configuration file.
        public GameContext()
            : base("name=GameContext")
        {
        }

        public DbSet<User> ApplicationUsers { get; set; }
        public DbSet<Player> GameUsers { get; set; }
        public DbSet<Map> Maps { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}