namespace Orm.Services
{
    using Data;
    using Models.Models;
    using System;
    using System.Linq;

    public class PlayerService : Service
    {
        private readonly UnitOfWork unit;

        public PlayerService(UnitOfWork unit) : base(unit)
        {
            this.unit = unit;
        }

        public Player GetPlayerById(int id)
        {
            return this.unit.PlayerRepository.FindAll(player => player.Id == id).FirstOrDefault();
        }

        public Player GetPlayerByUserName(string username)
        {
            if (String.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username), "Username should not be null of empty!");
            }

            return this.unit.PlayerRepository.FindAll(player => player.Username == username).FirstOrDefault();
        }
    }
}