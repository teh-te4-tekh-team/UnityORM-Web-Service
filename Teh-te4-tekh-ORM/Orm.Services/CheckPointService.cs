namespace Orm.Services
{
    using Data.Interfaces;
    using Models.Models;
    using System;
    using System.Linq;

    public class CheckPointService : Service
    {
        private readonly IUnitOfWork unit;

        public CheckPointService(IUnitOfWork unit) : base(unit)
        {
            this.unit = unit;
        }

        public CheckPoint GetCheckPointById(int id)
        {
            return this.unit.CheckPointRepository.FindAll(check => check.Id == id).FirstOrDefault();
        }

        public CheckPoint GetCheckPointByX(float x)
        {
            return this.unit.CheckPointRepository.FindAll(check => Math.Abs(check.X - x) < 0).FirstOrDefault();
        }

        public CheckPoint GetCheckPointByY(float y)
        {
            return this.unit.CheckPointRepository.FindAll(check => Math.Abs(check.Y - y) < 0).FirstOrDefault();
        }

        public CheckPoint GetCheckPointByZ(float z)
        {
            return this.unit.CheckPointRepository.FindAll(check => Math.Abs(check.Id - z) < 0).FirstOrDefault();
        }
    }
}