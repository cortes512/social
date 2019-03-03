using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SocialPointTest.Ranking.Domain.Entities;

namespace SocialPointTest.Ranking.Application.Contracts
{
    public interface IRankingApplicationService
    {
        Task<List<UserScore>> GetRankingAsync(int top);
        List<UserScore> GetRelativeRanking(int at, int position);
        Task UpdateAbsoluteScoreAsync(int userId, int newScore);
        Task UpdateRelativeScoreAsync(int userId, int score);
    }
}
