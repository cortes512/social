using SocialPointTest.Ranking.Application.Contracts;
using SocialPointTest.Ranking.Application.Services;

namespace SocialPointTest.Ranking.Application.IoC.Factories
{
    public class RankingApplicationServiceFactory
    {
        public static IRankingApplicationService GetRankingApplicationService()
        {
            return new RankingApplicationService(UserScoreRepositoryFactory.GetUserScoreRepository());
        }

    }
}
