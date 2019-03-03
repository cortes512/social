using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;

using SocialPointTest.Ranking.Application.Services;
using SocialPointTest.Ranking.Domain.Repositories;

namespace SocialPointTest.Ranking.Application.TDD.RankingService
{
    [TestFixture]
    public class GetRanking : TestBase<RankingApplicationService>
    {
        [Test]
        public void ShouldGetRankingTop5()
        {
            //arrange
            this.Mock<IUserScore>()
            .Setup(x => x.GetRanking(5));

            //act
            this.service.GetRanking(5);

            //assert
            this.Mock<IUserScore>()
            .Verify(x => x.GetRanking(5), Times.Once);
        }

        [Test]
        public void ShouldGetAllRanking()
        {
            //arrange
            this.Mock<IUserScore>()
            .Setup(x => x.GetAllRanking());

            //act
            this.service.GetRanking(0);

            //assert
            this.Mock<IUserScore>()
            .Verify(x => x.GetAllRanking(), Times.Once);
        }

    }
}
