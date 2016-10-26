using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using ORMServiceFramework.Models;

namespace ORMServiceFramework.Controllers
{
    public class PlayerController : ApiController
    {
        private GameContext gameContext = new GameContext();
            
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Player value)
        {
            this.gameContext.Players.Add(value);
            this.gameContext.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public IEnumerable<Player> Get()
        {
            return this.gameContext.Players.Select(x => x);
        }

        public Player Get(int id)
        {
            return this.gameContext.Players.FirstOrDefault();
        }
    }
}