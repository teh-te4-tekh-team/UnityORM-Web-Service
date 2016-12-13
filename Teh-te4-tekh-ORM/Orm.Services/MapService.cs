namespace Orm.Services
{
    using Data;
    using Models.Models;
    using System.Linq;

    public class MapService : Service
    {
        private readonly UnitOfWork unit;

        public MapService(UnitOfWork unit) : base(unit)
        {
            this.unit = unit;
        }

        public Map GetMapById(int id)
        {
            return this.unit.MapRepository.FindAll(map => map.Id == id).FirstOrDefault();
        }
    }
}