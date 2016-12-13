namespace Orm.Data.Interfaces
{
    using System.Data.Entity;
    using Models.Models;

    /// <summary>
    /// Contract containg several repositories.
    /// See <see cref="Orm.Models"/> for more details.>
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets the repository of the <seealso cref="CheckPoint"/> entities.
        /// </summary>
        IRepository<CheckPoint> CheckPointRepository { get; }

        /// <summary>
        /// Gets the repository of the <seealso cref="Collectable"/> entities.
        /// </summary>
        IRepository<Collectable> CollectibleRepository { get; }

        /// <summary>
        /// Gets the repository of the <seealso cref="Map"/> entities.
        /// </summary>
        IRepository<Map> MapRepository { get; }

        /// <summary>
        /// Gets the repository of the <seealso cref="Player"/> entities.
        /// </summary>
        IRepository<Player> PlayerRepository { get; }

        /// <summary>
        /// Gets the repository of the <seealso cref="SpawnPoint"/> entities.
        /// </summary>
        IRepository<SpawnPoint> SpawnPointRepository { get; }

        /// <summary>
        /// Gets the repository of the <seealso cref="User"/> entities.
        /// </summary>
        IRepository<User> UserRepository { get; }

        /// <summary>
        /// Save all changes made to all of the above repositories.
        /// May throw exception if any validation rules are not satisfied.
        /// See implementation for more details.
        /// </summary>
        void Commit();
        
        /// <summary>
        /// Calls inherited Dispose method.
        /// </summary>
        void Dispose();
    }
}