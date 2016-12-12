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

    public class MapsController : ApiController
    {
        private readonly GameContext db = new GameContext();

        // GET: api/Maps
        public IQueryable<Map> GetMaps()
        {
            return this.db.Maps;
        }

        // GET: api/Maps/5
        [ResponseType(typeof(Map))]
        public IHttpActionResult GetMap(int id)
        {
            Map map = this.db.Maps.Find(id);
            if (map == null)
            {
                return this.NotFound();
            }

            return this.Ok(map);
        }

        // PUT: api/Maps/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMap(int id, Map map)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != map.Id)
            {
                return this.BadRequest();
            }

            this.db.Entry(map).State = EntityState.Modified;

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.MapExists(id))
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

        // POST: api/Maps
        [ResponseType(typeof(Map))]
        public IHttpActionResult PostMap(Map map)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.db.Maps.Add(map);
            this.db.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = map.Id }, map);
        }

        // DELETE: api/Maps/5
        [ResponseType(typeof(Map))]
        public IHttpActionResult DeleteMap(int id)
        {
            Map map = this.db.Maps.Find(id);
            if (map == null)
            {
                return this.NotFound();
            }

            this.db.Maps.Remove(map);
            this.db.SaveChanges();

            return this.Ok(map);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MapExists(int id)
        {
            return this.db.Maps.Count(e => e.Id == id) > 0;
        }
    }
}