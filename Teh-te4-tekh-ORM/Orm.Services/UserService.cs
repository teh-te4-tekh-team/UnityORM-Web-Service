namespace Orm.Services
{
    using Data.Interfaces;
    using Models.Models;
    using System;
    using System.Linq;

    public class UserService : Service
    {
        private readonly IUnitOfWork unit;

        public UserService(IUnitOfWork unit) : base(unit)
        {
            this.unit = unit;
        }

        public User GetUserById(int id)
        {
            return this.unit.UserRepository.FindAll(user => user.Id == id).FirstOrDefault();
        }

        public User GetUserByEmail(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email), "The email cannot be empty!");
            }

            return this.unit.UserRepository.FindAll(user => user.Email == email).FirstOrDefault();
        }
    }
}