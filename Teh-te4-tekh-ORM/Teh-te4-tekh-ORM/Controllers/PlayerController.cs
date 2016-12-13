namespace Teh_te4_tekh_ORM.Controllers
{
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;

    using Orm.Data.Interfaces;
    using Orm.Models.Models;
    using Orm.Services;

    public class PlayerController : ApiController
    {
        private readonly IUnitOfWork unitOfWork = UnitOfWorkProvider.Instance;

        // GET: api/GameUser
        public IQueryable<Player> GetGameUsers()
        {
            return this.unitOfWork.PlayerRepository.FindAll(p => p.Id > 0).AsQueryable();
        }

        // GET: api/GameUser/5
        [ResponseType(typeof(Player))]
        public IHttpActionResult GetGameUser(int id)
        {
            Player gameUser = this.unitOfWork.PlayerRepository.GetById(id);
            if (gameUser == null)
            {
                return this.NotFound();
            }

            return this.Ok(gameUser);
        }

        // PUT: api/GameUser/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGameUser(int id, Player gameUser)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != gameUser.Id)
            {
                return this.BadRequest();
            }

            // this.unitOfWork.Entry(gameUser).State = EntityState.Modified;

            try
            {
                this.unitOfWork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.GameUserExists(id))
                {
                    return this.NotFound();
                }
                throw;
            }

            return this.StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/GameUser
        [ResponseType(typeof(Player))]
        public IHttpActionResult PostGameUser(User applicationUser)
        {

            if (this.GameUserExists(applicationUser.Id))
            {
                Player user = this.unitOfWork.PlayerRepository.GetById(applicationUser.Id);
                return this.CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
            }

            Player gameUser = new Player
            {
                Id = applicationUser.Id,
                Username = applicationUser.Email
            };

            this.unitOfWork.PlayerRepository.Add(gameUser);

            try
            {
                this.unitOfWork.Commit();
            }
            catch (DbUpdateException)
            {
                if (this.GameUserExists(gameUser.Id))
                {
                    return this.Conflict();
                }

                return this.BadRequest();
            }

            return this.CreatedAtRoute("DefaultApi", new { id = gameUser.Id }, gameUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameUserExists(int id)
        {
            return this.unitOfWork.PlayerRepository.GetById(id) == null ? false : true;
        }
    }
}