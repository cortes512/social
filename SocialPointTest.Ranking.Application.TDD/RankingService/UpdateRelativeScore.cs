using System;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;

using SocialPointTest.Ranking.Application.Contracts;
using SocialPointTest.Ranking.Application.IoC.Factories;
using SocialPointTest.Ranking.Application.Services;
using SocialPointTest.Ranking.Domain.Entities;
using SocialPointTest.Ranking.Domain.Repositories;

namespace SocialPointTest.Ranking.Application.TDD.RankingService
{
    [TestFixture]
    public class UpdateRelativeScore : TestBase<RankingApplicationService>
    {
        [Test]
        public async Task ShouldUpdateRelativeScore()
        {
            //arrange
            var userScore = new UserScore(new User { Id = 1, Name = "PlayerTest" }, 200);

            this.Mock<IUserScore>()
            .Setup(x => x.GetUserScoreByUserIdAsync(userScore.User.Id))
            .Returns(Task.FromResult(userScore));

            //act
            await this.service.UpdateRelativeScoreAsync(userScore.User.Id, 100);

            //assert
            this.Mock<IUserScore>()
            .Verify(x => x.UpdateRelativeScore(userScore.User.Id, 100), Times.Once);
        }

        [Test]
        public void ShouldThrowNotFoundException()
        {
            //arrange
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
