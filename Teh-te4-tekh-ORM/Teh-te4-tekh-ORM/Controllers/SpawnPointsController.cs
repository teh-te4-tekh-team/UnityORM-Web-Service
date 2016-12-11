namespace Teh_te4_tekh_ORM.Controllers
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;

    using Models;

    public class SpawnPointsController : ApiController
    {
        private GameContext db = new GameContext();

        // GET: api/SpawnPoints
        public IQueryable<SpawnPoint> GetSpawnPoints()
        {
            return db.SpawnPoints;
        }

        // GET: api/SpawnPoints/5
        [ResponseType(typeof(SpawnPoint))]
        public IHttpActionResult GetSpawnPoint(int id)
        {
            SpawnPoint spawnPoint = db.SpawnPoints.Find(id);
            if (spawnPoint == null)
            {
                return NotFound();
            }

            return Ok(spawnPoint);
        }

        // PUT: api/SpawnPoints/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSpawnPoint(int id, SpawnPoint spawnPoint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spawnPoint.Id)
            {
                return BadRequest();
            }

            db.Entry(spawnPoint).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpawnPointExists(id))
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

        // POST: api/SpawnPoints
        [ResponseType(typeof(SpawnPoint))]
        public IHttpActionResult PostSpawnPoint(SpawnPoint spawnPoint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SpawnPoints.Add(spawnPoint);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = spawnPoint.Id }, spawnPoint);
        }

        // DELETE: api/SpawnPoints/5
        [ResponseType(typeof(SpawnPoint))]
        public IHttpActionResult DeleteSpawnPoint(int id)
        {
            SpawnPoint spawnPoint = db.SpawnPoints.Find(id);
            if (spawnPoint == null)
            {
                return NotFound();
            }

            db.SpawnPoints.Remove(spawnPoint);
            db.SaveChanges();

            return Ok(spawnPoint);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpawnPointExists(int id)
        {
            return db.SpawnPoints.Count(e => e.Id == id) > 0;
        }
    }
}