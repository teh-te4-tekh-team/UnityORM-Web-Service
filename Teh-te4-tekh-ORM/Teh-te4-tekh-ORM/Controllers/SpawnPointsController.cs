namespace Teh_te4_tekh_ORM.Controllers
{
    using Orm.Data;
    using Orm.Models.Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;

    public class SpawnPointsController : ApiController
    {
        private readonly GameContext db = new GameContext();

        // GET: api/SpawnPoints
        public IQueryable<SpawnPoint> GetSpawnPoints()
        {
            return this.db.SpawnPoints;
        }

        // GET: api/SpawnPoints/5
        [ResponseType(typeof(SpawnPoint))]
        public IHttpActionResult GetSpawnPoint(int id)
        {
            SpawnPoint spawnPoint = this.db.SpawnPoints.Find(id);
            if (spawnPoint == null)
            {
                return this.NotFound();
            }

            return this.Ok(spawnPoint);
        }

        // PUT: api/SpawnPoints/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSpawnPoint(int id, SpawnPoint spawnPoint)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != spawnPoint.Id)
            {
                return this.BadRequest();
            }

            this.db.Entry(spawnPoint).State = EntityState.Modified;

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.SpawnPointExists(id))
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

        // POST: api/SpawnPoints
        [ResponseType(typeof(SpawnPoint))]
        public IHttpActionResult PostSpawnPoint(SpawnPoint spawnPoint)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.db.SpawnPoints.Add(spawnPoint);
            this.db.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = spawnPoint.Id }, spawnPoint);
        }

        // DELETE: api/SpawnPoints/5
        [ResponseType(typeof(SpawnPoint))]
        public IHttpActionResult DeleteSpawnPoint(int id)
        {
            SpawnPoint spawnPoint = this.db.SpawnPoints.Find(id);
            if (spawnPoint == null)
            {
                return this.NotFound();
            }

            this.db.SpawnPoints.Remove(spawnPoint);
            this.db.SaveChanges();

            return this.Ok(spawnPoint);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpawnPointExists(int id)
        {
            return this.db.SpawnPoints.Count(e => e.Id == id) > 0;
        }
    }
}