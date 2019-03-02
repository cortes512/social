using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialPointTest.Ranking.WebApi.Controllers
{
    [RoutePrefix("Ranking")]
    public class RankingController : ApiController
    {
        [Route("Hello")]
        [HttpGet]
        public string Hello()
        {
            return "Hello";
        }
    }
}
