namespace Orm.Data
{
    using Interfaces;
    using Models.Models;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly GameContext context = new GameContext();

        private IRepository<CheckPoint> checkPoint;
        private IRepository<Collectable> collectable;
        private IRepository<Map> map;
        private IRepository<Player> player;
        private IRepository<SpawnPoint> spawnPoint;
        private IRepository<User> user;

        public IRepository<CheckPoint> CheckPointRepository
        {
            get
            {
                return this.checkPoint ??
                       (this.checkPoint = new Repository<CheckPoint>(this.context.Set<CheckPoint>()));
            }
        }

        public IRepository<Collectable> CollectibleRepository
        {
            get
            {
                return this.collectable ??
                       (this.collectable = new Repository<Collectable>(this.context.Set<Collectable>()));
            }
        }

        public IRepository<Map> MapRepository
        {
            get
            {
                return this.map ??
                     (this.map = new Repository<Map>(this.context.Set<Map>()));
            }
        }

        public IRepository<Player> PlayerRepository
        {
            get
            {
                return this.player ??
                  (this.player = new Repository<Player>(this.context.Set<Player>()));
            }
        }

        public IRepository<SpawnPoint> SpawnPointRepository
        {
            get
            {
                return this.spawnPoint ??
                (this.spawnPoint = new Repository<SpawnPoint>(this.context.Set<SpawnPoint>()));
            }
        }

        public IRepository<User> UserRepository
        {
            get
            {
                return this.user ??
              (this.user = new Repository<User>(this.context.Set<User>()));
            }
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}