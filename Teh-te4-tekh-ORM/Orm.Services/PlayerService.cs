namespace Orm.Services
{
    using System;
    using System.Linq;

    using Models.Models;
    using Data.Interfaces;

    public class PlayerService : Service
    {
        private readonly IUnitOfWork unit;

        public PlayerService(IUnitOfWork unit) : base(unit)
        {
            this.unit = unit;
        }

        public Player GetPlayerById(int id)
        {
            return this.unit.PlayerRepository.GetById(id);
        }

        public Player GetPlayerByUserName(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username), "Username should not be null of empty!");
            }

            return this.unit.PlayerRepository.FindAll(player => player.Username == username).FirstOrDefault();
        }
    }
}