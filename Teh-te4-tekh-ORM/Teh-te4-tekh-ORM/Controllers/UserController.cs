namespace Teh_te4_tekh_ORM.Controllers
{
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Orm.Data.Implementations;
    using Orm.Models.Models;
    using Orm.Data.Interfaces;

    public class UserController : ApiController
    {

        private readonly IUnitOfWork unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/ApplicationUser
        public IQueryable<User> GetApplicationUsers()
        {
            return this.unitOfWork.UserRepository.FindAll(u => u.Id > 0).AsQueryable();
        }

        // GET: api/ApplicationUser/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetApplicationUser(int id)
        {
            User applicationUser = this.unitOfWork.UserRepository.GetById(id);
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

            // this.unitOfWork.Entry(applicationUser).State = EntityState.Modified;

            try
            {
                this.unitOfWork.Commit();
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

        // POST: api/User
        [ResponseType(typeof(User))]
        public IHttpActionResult PostApplicationUser(User applicationUser)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            User user =
                this.unitOfWork.UserRepository.SingleOrDefault(
                    u => u.Email.Equals(applicationUser.Email) && u.Password.Equals(applicationUser.Password));

            if (user != null)
            {
                return this.CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
            }

            this.unitOfWork.UserRepository.Add(applicationUser);

            try
            {
                this.unitOfWork.Commit();
            }
            catch (DbUpdateException)
            {
                return this.Conflict();
            }

            return this.Created("", applicationUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicationUserExists(int id)
        {
            return this.unitOfWork.UserRepository.GetById(id) != null;
        }
    }
}