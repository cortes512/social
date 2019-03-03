using SocialPointTest.Ranking.Domain.Repositories;
using SocialPointTest.Ranking.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPointTest.Ranking.Infrastructure.IoC.Factories
{
    public class UserScoreRepositoryFactory
    {
        public static IUserScore GetUserScoreRepository()
        {
            return UserScoreRepository.Instance();
        }
    }
}
