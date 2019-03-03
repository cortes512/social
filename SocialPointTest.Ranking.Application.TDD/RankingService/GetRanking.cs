using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialPointTest.Ranking.Domain.Entities;
using SocialPointTest.Ranking.Domain.Repositories;

namespace SocialPointTest.Ranking.Application.TDD.RankingService
{
    [TestClass]
    public class GetRanking :TestBase<Services.RankingApplicationService>
    {
        [TestMethod]
        public async Task ShouldGetRanking()
        {
            //arrange
            this.Init();

            //act
            var result = await this.service.GetRankingAsync(5);

            //assert
            result.Should().HaveCount(5);
        }
    }
}
