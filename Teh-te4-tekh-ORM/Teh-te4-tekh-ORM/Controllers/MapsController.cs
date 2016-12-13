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

    public class MapsController : ApiController
    {
        private readonly IUnitOfWork unitOfWork = UnitOfWorkProvider.Instance;

        // GET: api/Maps
        public IQueryable<Map> GetMaps()
        {
            return this.unitOfWork.MapRepository.FindAll(m => m.Id > 0).AsQueryable();
        }

        // GET: api/Maps/5
        [ResponseType(typeof(Map))]
        public IHttpActionResult GetMap(int id)
        {
            Map map = this.unitOfWork.MapRepository.GetById(id);
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

            // this.unitOfWork.Entry(map).State = EntityState.Modified;

            try
            {
                this.unitOfWork.Commit();
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

            this.unitOfWork.MapRepository.Add(map);
            this.unitOfWork.Commit();

            return this.CreatedAtRoute("DefaultApi", new { id = map.Id }, map);
        }

        // DELETE: api/Maps/5
        [ResponseType(typeof(Map))]
        public IHttpActionResult DeleteMap(int id)
        {
            Map map = this.unitOfWork.MapRepository.GetById(id);
            if (map == null)
            {
                return this.NotFound();
            }

            this.unitOfWork.MapRepository.Delete(map);
            this.unitOfWork.Commit();

            return this.Ok(map);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MapExists(int id)
        {
            return this.unitOfWork.MapRepository.GetById(id) == null ? false : true;
        }
    }
}