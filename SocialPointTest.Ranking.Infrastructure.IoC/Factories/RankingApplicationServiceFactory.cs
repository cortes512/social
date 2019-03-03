using SocialPointTest.Ranking.Application.Contracts;
using SocialPointTest.Ranking.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPointTest.Ranking.Infrastructure.IoC.Factories
{
    public class RankingApplicationServiceFactory
    {
        public static IRankingApplicationService GetRankingApplicationService()
        {
            return new RankingApplicationService(UserScoreRepositoryFactory.GetUserScoreRepository());
        }
    }
}
