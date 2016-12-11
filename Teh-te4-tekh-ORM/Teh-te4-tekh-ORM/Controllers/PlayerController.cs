namespace Teh_te4_tekh_ORM.Controllers
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;

    using Models;

    public class PlayerController : ApiController
    {
        private readonly GameContext db = new GameContext();

        // GET: api/GameUser
        public IQueryable<Player> GetGameUsers()
        {
            return db.GameUsers;
        }

        // GET: api/GameUser/5
        [ResponseType(typeof(Player))]
        public IHttpActionResult GetGameUser(int id)
        {
            Player gameUser = db.GameUsers.Find(id);
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

            this.db.Entry(gameUser).State = EntityState.Modified;

            try
            {
                this.db.SaveChanges();
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
                Player user = this.db.GameUsers.Find(applicationUser.Id);
                return this.CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
            }

            Player gameUser = new Player
            {
                Id = applicationUser.Id,
                Username = applicationUser.Email
            };

            this.db.GameUsers.Add(gameUser);
            
            try
            {
                this.db.SaveChanges();
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
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameUserExists(int id)
        {
            return db.GameUsers.Count(e => e.Id == id) > 0;
        }
    }
}