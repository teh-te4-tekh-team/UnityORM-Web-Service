namespace Orm.Services
{
    using Data.Interfaces;
    using Models.Models;

    public class MapService : Service
    {
        private readonly IUnitOfWork unit;

        public MapService(IUnitOfWork unit) : base(unit)
        {
            this.unit = unit;
        }

        public Map GetMapById(int id)
        {
            return this.unit.MapRepository.GetById(id);
        }
    }
}