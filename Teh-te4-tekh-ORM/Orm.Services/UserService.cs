namespace Orm.Services
{
    using System;
    using System.Linq;

    using Data.Interfaces;
    using Models.Models;

    public class UserService : Service
    {
        private readonly IUnitOfWork unit;

        public UserService(IUnitOfWork unit) : base(unit)
        {
            this.unit = unit;
        }

        public User GetUserById(int id)
        {
            return this.unit.UserRepository.GetById(id);
        }

        public User GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email), "The email cannot be empty!");
            }

            return this.unit.UserRepository.FindAll(user => user.Email == email).FirstOrDefault();
        }
    }
}