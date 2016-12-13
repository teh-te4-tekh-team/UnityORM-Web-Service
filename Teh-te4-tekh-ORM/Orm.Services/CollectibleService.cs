namespace Orm.Services
{
    using Data.Interfaces;
    using Models.Models;
    using System;
    using System.Linq;

    public class CollectibleService : Service
    {
        private readonly IUnitOfWork unit;

        public CollectibleService(IUnitOfWork unit) : base(unit)
        {
            this.unit = unit;
        }

        public Collectable GetCollectableByValue(float value)
        {
            return this.unit.CollectibleRepository.FindAll(collect => Math.Abs(collect.Value - value) < 0).FirstOrDefault();
        }
    }
}