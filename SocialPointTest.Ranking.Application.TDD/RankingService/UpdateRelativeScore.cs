using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SocialPointTest.Ranking.Application.Services;
using SocialPointTest.Ranking.Domain.Entities;
using SocialPointTest.Ranking.Domain.Repositories;

namespace SocialPointTest.Ranking.Application.TDD.RankingService
{
    [TestClass]
    public class UpdateRelativeScore : TestBase<RankingApplicationService>
    {
        [TestMethod]
        public async Task ShouldUpdateRelativeScore()
        {
            //arrange
            this.Init();
            var userScore = new UserScore(new User { Id = 1, Name = "PlayerTest" }, 200);

            this.Mock<IUserScore>()
            .Setup(x => x.GetUserScoreByUserIdAsync(userScore.User.Id))
            .Returns(Task.FromResult(userScore));

            //act
            await this.service.UpdateRelativeScoreAsync(userScore.User.Id, 100);

            //assert
            userScore.Score.Should().Be(300);
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
            Func<Task> action = async () => await this.service.UpdateRelativeScoreAsync(userScore.User.Id, userScore.Score);

            //assert
            action.Should().Throw<Domain.Exceptions.NotFoundException>();
        }
    }
}
