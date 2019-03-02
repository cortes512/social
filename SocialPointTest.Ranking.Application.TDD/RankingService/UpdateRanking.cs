using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialPointTest.Ranking.Domain.Entities;
using SocialPointTest.Ranking.Domain.Repositories;

namespace SocialPointTest.Ranking.Application.TDD.RankingService
{
    [TestClass]
    public class UpdateRanking : TestBase<Services.RankingApplicationService>
    {
        [TestMethod]
        public async Task ShouldUpdateAbsoluteScore()
        {
            //arrange
            var userScore = new UserScore(new User { Id = 1, Name = "PlayerTest" }, 200);

            this.Mock<IUserScore>()
            .Setup(x => x.GetUserScoreByUserIdAsync(userScore.User.Id))
            .Returns(Task.FromResult(userScore));

            //act
            await this.service.UpdateAbsoluteScore(userScore, 300);


            //assert
        }
    }
}
