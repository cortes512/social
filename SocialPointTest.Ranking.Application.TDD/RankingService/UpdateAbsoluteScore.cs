using System;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;

using SocialPointTest.Ranking.Domain.Entities;
using SocialPointTest.Ranking.Domain.Repositories;

namespace SocialPointTest.Ranking.Application.TDD.RankingService
{
    [TestFixture]
    public class UpdateAbsoluteScore : TestBase<Services.RankingApplicationService>
    {
        [Test]
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
            this.Mock<IUserScore>()
            .Verify(x => x.UpdateAbsoluteScore(userScore.User.Id, 200), Times.Once);

        }

        [Test]
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
