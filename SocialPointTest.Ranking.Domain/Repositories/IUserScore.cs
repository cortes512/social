using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SocialPointTest.Ranking.Domain.Entities;

namespace SocialPointTest.Ranking.Domain.Repositories
{
    public interface IUserScore
    {
        Task<UserScore> GetUserScoreByUserIdAsync(int userId);
        Task<List<UserScore>> GetRankingAsync(int top);
        void UpdateAbsoluteScore(int userId, int newScore);
        void UpdateRelativeScore(int userId, int score);
    }
}
