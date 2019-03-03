using SocialPointTest.Ranking.Domain.Repositories;
using SocialPointTest.Ranking.Infrastructure.Repositories;

namespace SocialPointTest.Ranking.Application.IoC.Factories
{
    public class UserScoreRepositoryFactory
    {
        public static IUserScore GetUserScoreRepository()
        {
            return UserScoreRepository.Instance();
        }
    }
}
