using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TicTacToe.Data;

namespace TicTacToe.Web.Controllers
{
    public class BestPlayerController : ApiController
    {
        private readonly ITicTacToeData data;

        [HttpGet]
        [Route("/api/scores")]
        public IHttpActionResult GetBest()
        {
            var best = this.data.Users.All().OrderBy(x => x.Scores).FirstOrDefault();
            if (best == null)
            {
                return NotFound();
            }

            return Ok(best);
        }
    }
}
