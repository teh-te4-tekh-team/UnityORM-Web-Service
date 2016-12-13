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

    public class CollectablesController : ApiController
    {
        private readonly IUnitOfWork unitOfWork = UnitOfWorkProvider.Instance;

        // GET: api/Collectables
        public IQueryable<Collectable> GetCollectables()
        {
            return this.unitOfWork.CollectibleRepository.FindAll(c => c.Id > 0).AsQueryable();
        }

        // GET: api/Collectables/5
        [ResponseType(typeof(Collectable))]
        public IHttpActionResult GetCollectable(int id)
        {
            Collectable collectable = this.unitOfWork.CollectibleRepository.GetById(id);
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

            // Same sh*t as CheckpointsController
            // this.db.Entry(collectable).State = EntityState.Modified;

            try
            {
                this.unitOfWork.Commit();
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

            this.unitOfWork.CollectibleRepository.Add(collectable);
            this.unitOfWork.Commit();

            return this.CreatedAtRoute("DefaultApi", new { id = collectable.Id }, collectable);
        }

        // DELETE: api/Collectables/5
        [ResponseType(typeof(Collectable))]
        public IHttpActionResult DeleteCollectable(int id)
        {
            Collectable collectable = this.unitOfWork.CollectibleRepository.GetById(id);
            if (collectable == null)
            {
                return this.NotFound();
            }

            this.unitOfWork.CollectibleRepository.Delete(collectable);
            this.unitOfWork.Commit();

            return this.Ok(collectable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.unitOfWork.Dispose();
            }

            base.Dispose(disposing);
        }

        private bool CollectableExists(int id)
        {
            return this.unitOfWork.CollectibleRepository.GetById(id) == null ? false : true;
        }
    }
}