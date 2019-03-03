using SocialPointTest.Ranking.Domain.Entities;
using SocialPointTest.Ranking.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPointTest.Ranking.Application.Services
{
    public class RankingApplicationService : Contracts.IRankingApplicationService
    {
        IUserScore ScoreRepository;

        public RankingApplicationService(IUserScore userScoreRepository)
        {
            this.ScoreRepository = userScoreRepository;
        }

        public async Task UpdateAbsoluteScoreAsync(int userId, int newScore)
        {
            var userScore = await ScoreRepository.GetUserScoreByUserIdAsync(userId);
            if (userScore == null)
            {
                throw new Domain.Exceptions.NotFoundException();
            }
            ScoreRepository.UpdateAbsoluteScore(userId, newScore);
        }

        public async Task UpdateRelativeScoreAsync(int userId, int score)
        {
            var userScore = await ScoreRepository.GetUserScoreByUserIdAsync(userId);
            if (userScore == null)
            {
                throw new Domain.Exceptions.NotFoundException();
            }
            ScoreRepository.UpdateRelativeScore(userId, score);
        }

        public async Task<List<UserScore>> GetRankingAsync(int top)
        {
            return await ScoreRepository.GetRankingAsync(top);
        }
    }
}
