namespace Teh_te4_tekh_ORM.Controllers
{
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Orm.Data.Implementations;
    using Orm.Data.Interfaces;
    using Orm.Models.Models;

    public class SpawnPointsController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public SpawnPointsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: api/SpawnPoints
        public IQueryable<SpawnPoint> GetSpawnPoints()
        {
            return this.unitOfWork.SpawnPointRepository.FindAll(sp => sp.Id > 0).AsQueryable();
        }

        // GET: api/SpawnPoints/5
        [ResponseType(typeof(SpawnPoint))]
        public IHttpActionResult GetSpawnPoint(int id)
        {
            SpawnPoint spawnPoint = this.unitOfWork.SpawnPointRepository.GetById(id);
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

            // this.unitOfWork.Entry(spawnPoint).State = EntityState.Modified;

            try
            {
                this.unitOfWork.Commit();
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

            this.unitOfWork.SpawnPointRepository.Add(spawnPoint);
            this.unitOfWork.Commit();

            return this.CreatedAtRoute("DefaultApi", new { id = spawnPoint.Id }, spawnPoint);
        }

        // DELETE: api/SpawnPoints/5
        [ResponseType(typeof(SpawnPoint))]
        public IHttpActionResult DeleteSpawnPoint(int id)
        {
            SpawnPoint spawnPoint = this.unitOfWork.SpawnPointRepository.GetById(id);
            if (spawnPoint == null)
            {
                return this.NotFound();
            }

            this.unitOfWork.SpawnPointRepository.Delete(spawnPoint);
            this.unitOfWork.Commit();

            return this.Ok(spawnPoint);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpawnPointExists(int id)
        {
            return this.unitOfWork.SpawnPointRepository.GetById(id) != null;
        }
    }
}