using System.Threading.Tasks;
using System.Web.Http;

using SocialPointTest.Ranking.Application.Contracts;
using SocialPointTest.Ranking.Application.IoC.Factories;
using SocialPointTest.Ranking.WebApi.Extensions.Mappings;
using SocialPointTest.Ranking.WebApi.Models;

namespace SocialPointTest.Ranking.WebApi.Controllers
{
    [RoutePrefix("Ranking")]
    public class RankingController : ApiController
    {
        private readonly IRankingApplicationService RankingApplicationService;

        public RankingController()
        {
            this.RankingApplicationService = RankingApplicationServiceFactory.GetRankingApplicationService();
        }

        [Route("get-ranking/{top:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetRanking(int top)
        {
            var ranking = await RankingApplicationService.GetRankingAsync(top);

            return Json(ranking);
        }

        [Route("get-relative-ranking/{at:int}/{position:int}")]
        [HttpGet]
        public IHttpActionResult GetRanking(int at, int position)
        {
            var ranking = RankingApplicationService.GetRelativeRanking(at, position);

            return Json(ranking);
        }

        [Route("update-absoulte-score")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateAbsoluteScore([FromBody]UpdateAbsoluteScoreDto updateAbsoluteScoreDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userScore = updateAbsoluteScoreDto.MapToUserScore();
            await RankingApplicationService.UpdateAbsoluteScoreAsync(userScore.User.Id, userScore.Score);

            return Ok();
        }

        [Route("update-relative-score")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateRelativeScore([FromBody]UpdateRelativeScoreDto updateRelativeScoreDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userScore = updateRelativeScoreDto.MapToUserScore();
            await RankingApplicationService.UpdateRelativeScoreAsync(userScore.User.Id, userScore.Score);

            return Ok();
        }
    }
}
