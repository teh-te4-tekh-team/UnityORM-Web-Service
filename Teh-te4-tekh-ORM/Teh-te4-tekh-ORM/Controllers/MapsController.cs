namespace Teh_te4_tekh_ORM.Controllers
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;

    using Models;

    public class MapsController : ApiController
    {
        private GameContext db = new GameContext();

        // GET: api/Maps
        public IQueryable<Map> GetMaps()
        {
            return db.Maps;
        }

        // GET: api/Maps/5
        [ResponseType(typeof(Map))]
        public IHttpActionResult GetMap(int id)
        {
            Map map = db.Maps.Find(id);
            if (map == null)
            {
                return NotFound();
            }

            return Ok(map);
        }

        // PUT: api/Maps/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMap(int id, Map map)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != map.Id)
            {
                return BadRequest();
            }

            db.Entry(map).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MapExists(id))
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

        // POST: api/Maps
        [ResponseType(typeof(Map))]
        public IHttpActionResult PostMap(Map map)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Maps.Add(map);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = map.Id }, map);
        }

        // DELETE: api/Maps/5
        [ResponseType(typeof(Map))]
        public IHttpActionResult DeleteMap(int id)
        {
            Map map = db.Maps.Find(id);
            if (map == null)
            {
                return NotFound();
            }

            db.Maps.Remove(map);
            db.SaveChanges();

            return Ok(map);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MapExists(int id)
        {
            return db.Maps.Count(e => e.Id == id) > 0;
        }
    }
}