namespace Orm.Services
{
    using System;
    using System.Linq;

    using Data.Interfaces;
    using Models.Models;
    using Models;
    using System.Collections.Generic;

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

        public IEnumerable<Collectable> GetCollectablesByType(CollectableType type)
        {
            return this.unit.CollectibleRepository.FindAll(col => col.Type == type);
        }

        public Collectable GetCollectableById(int id)
        {
            return this.unit.CollectibleRepository.GetById(id);
        }
    }
}