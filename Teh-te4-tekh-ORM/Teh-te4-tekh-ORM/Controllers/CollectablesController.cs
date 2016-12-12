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

    public class CollectablesController : ApiController
    {
        private readonly GameContext db = new GameContext();

        // GET: api/Collectables
        public IQueryable<Collectable> GetCollectables()
        {
            return this.db.Collectables;
        }

        // GET: api/Collectables/5
        [ResponseType(typeof(Collectable))]
        public IHttpActionResult GetCollectable(int id)
        {
            Collectable collectable = this.db.Collectables.Find(id);
            if (collectable == null)
            {
                return this.NotFound();
            }

            return this.Ok(collectable);
        }

        // PUT: api/Collectables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCollectable(int id, Collectable collectable)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != collectable.Id)
            {
                return this.BadRequest();
            }

            this.db.Entry(collectable).State = EntityState.Modified;

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.CollectableExists(id))
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

        // POST: api/Collectables
        [ResponseType(typeof(Collectable))]
        public IHttpActionResult PostCollectable(Collectable collectable)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.db.Collectables.Add(collectable);
            this.db.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = collectable.Id }, collectable);
        }

        // DELETE: api/Collectables/5
        [ResponseType(typeof(Collectable))]
        public IHttpActionResult DeleteCollectable(int id)
        {
            Collectable collectable = this.db.Collectables.Find(id);
            if (collectable == null)
            {
                return this.NotFound();
            }

            this.db.Collectables.Remove(collectable);
            this.db.SaveChanges();

            return this.Ok(collectable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CollectableExists(int id)
        {
            return this.db.Collectables.Count(e => e.Id == id) > 0;
        }
    }
}