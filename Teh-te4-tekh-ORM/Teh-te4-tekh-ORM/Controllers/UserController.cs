﻿namespace Teh_te4_tekh_ORM.Controllers
{
    using Orm.Data;
    using Orm.Models.Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;

    public class UserController : ApiController
    {
        private readonly GameContext db = new GameContext();

        // GET: api/ApplicationUser
        public IQueryable<User> GetApplicationUsers()
        {
            return this.db.ApplicationUsers;
        }

        // GET: api/ApplicationUser/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetApplicationUser(int id)
        {
            User applicationUser = this.db.ApplicationUsers.Find(id);
            if (applicationUser == null)
            {
                return this.NotFound();
            }

            return this.Ok(applicationUser);
        }

        // PUT: api/ApplicationUser/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutApplicationUser(int id, User applicationUser)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != applicationUser.Id)
            {
                return this.BadRequest();
            }

            this.db.Entry(applicationUser).State = EntityState.Modified;

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.ApplicationUserExists(id))
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return this.StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ApplicationUser
        [ResponseType(typeof(User))]
        public IHttpActionResult PostApplicationUser(User applicationUser)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            User user =
                this.db.ApplicationUsers.SingleOrDefault(
                    au => au.Email.Equals(applicationUser.Email) && au.Password.Equals(applicationUser.Password));

            if (user != null)
            {
                return this.CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
            }

            this.db.ApplicationUsers.Add(applicationUser);

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return this.Conflict();
            }

            return this.CreatedAtRoute("DefaultApi", new { id = applicationUser.Id }, applicationUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicationUserExists(int id)
        {
            return this.db.ApplicationUsers.Count(e => e.Id == id) > 0;
        }
    }
}