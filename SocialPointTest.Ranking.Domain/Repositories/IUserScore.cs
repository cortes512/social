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
        List<UserScore> GetAllRanking();
        Task<List<UserScore>> GetAllRankingAsync();
        List<UserScore> GetRanking(int top);
        Task<List<UserScore>> GetRankingAsync(int top);
        Task<UserScore> GetUserScoreByUserIdAsync(int userId);
        void UpdateAbsoluteScore(int userId, int newScore);
        void UpdateRelativeScore(int userId, int score);
    }
}
