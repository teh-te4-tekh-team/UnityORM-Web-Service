namespace Teh_te4_tekh_ORM.Controllers
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Models;

    public class CheckPointsController : ApiController
    {
        private GameContext db = new GameContext();

        // GET: api/CheckPoints
        public IQueryable<CheckPoint> GetCheckPoints()
        {
            return db.CheckPoints;
        }

        // GET: api/CheckPoints/5
        [ResponseType(typeof(CheckPoint))]
        public IHttpActionResult GetCheckPoint(int id)
        {
            CheckPoint checkPoint = db.CheckPoints.Find(id);
            if (checkPoint == null)
            {
                return NotFound();
            }

            return Ok(checkPoint);
        }

        // PUT: api/CheckPoints/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCheckPoint(int id, CheckPoint checkPoint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != checkPoint.Id)
            {
                return BadRequest();
            }

            db.Entry(checkPoint).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckPointExists(id))
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

        // POST: api/CheckPoints
        [ResponseType(typeof(CheckPoint))]
        public IHttpActionResult PostCheckPoint(CheckPoint checkPoint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CheckPoints.Add(checkPoint);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = checkPoint.Id }, checkPoint);
        }

        // DELETE: api/CheckPoints/5
        [ResponseType(typeof(CheckPoint))]
        public IHttpActionResult DeleteCheckPoint(int id)
        {
            CheckPoint checkPoint = db.CheckPoints.Find(id);
            if (checkPoint == null)
            {
                return NotFound();
            }

            db.CheckPoints.Remove(checkPoint);
            db.SaveChanges();

            return Ok(checkPoint);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CheckPointExists(int id)
        {
            return db.CheckPoints.Count(e => e.Id == id) > 0;
        }
    }
}