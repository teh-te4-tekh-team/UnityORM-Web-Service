namespace Teh_te4_tekh_ORM.Controllers
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;

    using Models;

    public class CollectablesController : ApiController
    {
        private GameContext db = new GameContext();

        // GET: api/Collectables
        public IQueryable<Collectable> GetCollectables()
        {
            return db.Collectables;
        }

        // GET: api/Collectables/5
        [ResponseType(typeof(Collectable))]
        public IHttpActionResult GetCollectable(int id)
        {
            Collectable collectable = db.Collectables.Find(id);
            if (collectable == null)
            {
                return NotFound();
            }

            return Ok(collectable);
        }

        // PUT: api/Collectables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCollectable(int id, Collectable collectable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != collectable.Id)
            {
                return BadRequest();
            }

            db.Entry(collectable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollectableExists(id))
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

        // POST: api/Collectables
        [ResponseType(typeof(Collectable))]
        public IHttpActionResult PostCollectable(Collectable collectable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Collectables.Add(collectable);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = collectable.Id }, collectable);
        }

        // DELETE: api/Collectables/5
        [ResponseType(typeof(Collectable))]
        public IHttpActionResult DeleteCollectable(int id)
        {
            Collectable collectable = db.Collectables.Find(id);
            if (collectable == null)
            {
                return NotFound();
            }

            db.Collectables.Remove(collectable);
            db.SaveChanges();

            return Ok(collectable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CollectableExists(int id)
        {
            return db.Collectables.Count(e => e.Id == id) > 0;
        }
    }
}