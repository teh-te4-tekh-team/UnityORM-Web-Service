namespace Teh_te4_tekh_ORM.Controllers
{
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;

    using Orm.Models.Models;
    using Orm.Services;
    using Orm.Data.Interfaces;

    public class CheckPointsController : ApiController
    {
        private readonly IUnitOfWork unitOfWork = UnitOfWorkProvider.Instance;

        // GET: api/CheckPoints
        public IQueryable<CheckPoint> GetCheckPoints()
        {
            return this.unitOfWork.CheckPointRepository.FindAll(cp => cp.Id > 0).AsQueryable();
        }

        // GET: api/CheckPoints/5
        [ResponseType(typeof(CheckPoint))]
        public IHttpActionResult GetCheckPoint(int id)
        {
            CheckPoint checkPoint = this.unitOfWork.CheckPointRepository.GetById(id);
            if (checkPoint == null)
            {
                return this.NotFound();
            }

            return this.Ok(checkPoint);
        }

        // PUT: api/CheckPoints/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCheckPoint(int id, CheckPoint checkPoint)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != checkPoint.Id)
            {
                return this.BadRequest();
            }

            // Warn!
            // Marking the state of an entry as modified. This might be needed in our UoW as well.
            // this.unitOfWork.Entry(checkPoint).State = EntityState.Modified;

            try
            {
                this.unitOfWork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.CheckPointExists(id))
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

        // POST: api/CheckPoints
        [ResponseType(typeof(CheckPoint))]
        public IHttpActionResult PostCheckPoint(CheckPoint checkPoint)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.unitOfWork.CheckPointRepository.Add(checkPoint);
            this.unitOfWork.Commit();

            return this.CreatedAtRoute("DefaultApi", new { id = checkPoint.Id }, checkPoint);
        }

        // DELETE: api/CheckPoints/5
        [ResponseType(typeof(CheckPoint))]
        public IHttpActionResult DeleteCheckPoint(int id)
        {
            CheckPoint checkPoint = this.unitOfWork.CheckPointRepository.GetById(id);
            if (checkPoint == null)
            {
                return this.NotFound();
            }

            this.unitOfWork.CheckPointRepository.Delete(checkPoint);
            this.unitOfWork.Commit();

            return this.Ok(checkPoint);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.unitOfWork.Dispose();
            }

            base.Dispose(disposing);
        }

        private bool CheckPointExists(int id)
        {
            return this.unitOfWork.CheckPointRepository.GetById(id) == null ? false : true;
        }
    }
}