namespace Orm.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Data.Interfaces;
    using Models.Models;
    using System.Linq.Expressions;

    public class CheckPointService : Service
    {
        private readonly IUnitOfWork unit;

        public CheckPointService(IUnitOfWork unit) : base(unit)
        {
            this.unit = unit;
        }

        public CheckPoint GetCheckPointById(int id)
        {
            return this.unit.CheckPointRepository.GetById(id);
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

        public CheckPoint GetCheckPointByCoordinates(float x, float y, float z)
        {
            return this.unit.CheckPointRepository.FindAll(check => check.X == x && check.Y == y && check.Z == z).FirstOrDefault();
        }

        public IEnumerable<CheckPoint> GetAllCheckpoints()
        {
            return this.unit.CheckPointRepository.FindAll(c => c.Id > 0);
        }

        public IEnumerable<CheckPoint> FindAll(Expression<Func<CheckPoint, bool>> where)
        {
            return this.unit.CheckPointRepository.FindAll(where);
        }
    }
}