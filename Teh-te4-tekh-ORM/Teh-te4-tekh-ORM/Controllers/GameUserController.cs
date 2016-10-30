using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Teh_te4_tekh_ORM.Models;

namespace Teh_te4_tekh_ORM.Controllers
{
    public class GameUserController : ApiController
    {
        private readonly GameContext db = new GameContext();

        // GET: api/GameUser
        public IQueryable<GameUser> GetGameUsers()
        {
            return db.GameUsers;
        }

        // GET: api/GameUser/5
        [ResponseType(typeof(GameUser))]
        public IHttpActionResult GetGameUser(int id)
        {
            GameUser gameUser = db.GameUsers.Find(id);
            if (gameUser == null)
            {
                return this.NotFound();
            }

            return this.Ok(gameUser);
        }

        // PUT: api/GameUser/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGameUser(int id, GameUser gameUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gameUser.GameUserID)
            {
                return BadRequest();
            }

            db.Entry(gameUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/GameUser
        [ResponseType(typeof(GameUser))]
        public IHttpActionResult PostGameUser(ApplicationUser applicationUser)
        {
            if (this.GameUserExists(applicationUser.ApplicationUserID))
            {
                GameUser user = this.db.GameUsers.Find(applicationUser.ApplicationUserID);
                return this.CreatedAtRoute("DefaultApi", new { id = user.GameUserID }, user);
            }

            GameUser gameUser = new GameUser
            {
                GameUserID = applicationUser.ApplicationUserID,
                Username = applicationUser.Email
            };

            this.db.GameUsers.Add(gameUser);
            
            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (this.GameUserExists(gameUser.GameUserID))
                {
                    return this.Conflict();
                }

                return this.BadRequest();
            }

            return this.CreatedAtRoute("DefaultApi", new { id = gameUser.GameUserID }, gameUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameUserExists(int id)
        {
            return db.GameUsers.Count(e => e.GameUserID == id) > 0;
        }
    }
}