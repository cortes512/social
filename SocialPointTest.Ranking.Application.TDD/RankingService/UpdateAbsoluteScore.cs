using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

using SocialPointTest.Ranking.Domain.Entities;
using SocialPointTest.Ranking.Domain.Repositories;


namespace SocialPointTest.Ranking.Application.TDD.RankingService
{
    [TestClass]
    public class UpdateAbsoluteScore : TestBase<Services.RankingApplicationService>
    {
        [TestMethod]
        public async Task ShouldUpdateAbsoluteScore()
        {
            //arrange
            this.Init();
            var userScore = new UserScore (new User { Id = 1, Name = "PlayerTest" }, 200 );

            this.Mock<IUserScore>()
            .Setup(x => x.GetUserScoreByUserIdAsync(userScore.User.Id))
            .Returns(Task.FromResult(userScore));

            //act
            await this.service.UpdateAbsoluteScoreAsync(userScore.User.Id, userScore.Score);

            //assert
            userScore.Score.Should().Be(userScore.Score);
        }

        [TestMethod]
        public void ShouldThrowNotFoundException()
        {
            //arrange
            this.Init();
            var userScore = new UserScore(new User { Id = 1, Name = "PlayerTest" }, 200);

            this.Mock<IUserScore>()
            .Setup(x => x.GetUserScoreByUserIdAsync(userScore.User.Id))
            .Throws<Domain.Exceptions.NotFoundException>();

            //act
            Func<Task> action = async () => await this.service.UpdateAbsoluteScoreAsync(userScore.User.Id, userScore.Score);

            //assert
            action.Should().Throw<Domain.Exceptions.NotFoundException>();
        }
    }
}
