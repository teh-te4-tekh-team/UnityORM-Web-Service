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

    public class CheckPointsController : ApiController
    {
        private readonly GameContext db = new GameContext();

        // GET: api/CheckPoints
        public IQueryable<CheckPoint> GetCheckPoints()
        {
            return this.db.CheckPoints;
        }

        // GET: api/CheckPoints/5
        [ResponseType(typeof(CheckPoint))]
        public IHttpActionResult GetCheckPoint(int id)
        {
            CheckPoint checkPoint = this.db.CheckPoints.Find(id);
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

            this.db.Entry(checkPoint).State = EntityState.Modified;

            try
            {
                this.db.SaveChanges();
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

            this.db.CheckPoints.Add(checkPoint);
            this.db.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = checkPoint.Id }, checkPoint);
        }

        // DELETE: api/CheckPoints/5
        [ResponseType(typeof(CheckPoint))]
        public IHttpActionResult DeleteCheckPoint(int id)
        {
            CheckPoint checkPoint = this.db.CheckPoints.Find(id);
            if (checkPoint == null)
            {
                return this.NotFound();
            }

            this.db.CheckPoints.Remove(checkPoint);
            this.db.SaveChanges();

            return this.Ok(checkPoint);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CheckPointExists(int id)
        {
            return this.db.CheckPoints.Count(e => e.Id == id) > 0;
        }
    }
}