namespace Orm.Services
{
    using Data.Interfaces;
    using Models.Models;
    using System.Linq;

    public class SpawnPointService : Service
    {
        private readonly IUnitOfWork unit;

        public SpawnPointService(IUnitOfWork unit) : base(unit)
        {
            this.unit = unit;
        }

        public SpawnPoint GetSpawnPointId(int id)
        {
            return this.unit.SpawnPointRepository.FindAll(spawn => spawn.Id == id).FirstOrDefault();
        }
    }
}