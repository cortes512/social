using SocialPointTest.Ranking.Application.Contracts;
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
        private readonly IRankingApplicationService RankingApplicationService;

        public RankingController(IRankingApplicationService rankingApplicationService)
        {
            this.RankingApplicationService = rankingApplicationService;
        }

        [Route("get-ranking/{top:int}")]
        [HttpGet]
        public string GetRanking(int top)
        {

            return "Hello"+top.ToString();
        }
    }
}
