namespace Orm.Data.Interfaces
{
    using Models.Models;

    public interface IUnitOfWork
    {
        IRepository<CheckPoint> CheckPointRepository { get; }

        IRepository<Collectable> CollectibleRepository { get; }

        IRepository<Map> MapRepository { get; }

        IRepository<Player> PlayerRepository { get; }

        IRepository<SpawnPoint> SpawnPointRepository { get; }

        IRepository<User> UserRepository { get; }

        void Commit();
    }
}