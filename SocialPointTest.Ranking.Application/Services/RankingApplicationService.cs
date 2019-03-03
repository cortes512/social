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

        public List<UserScore> GetRanking(int top)
        {
            return ScoreRepository.GetRanking(0);
        }

        public async Task<List<UserScore>> GetRankingAsync(int top)
        {
            return await ScoreRepository.GetRankingAsync(top);
        }

        public List<UserScore> GetRelativeRanking(int at, int position)
        {
            var ranking = GetRanking(0);
            List<UserScore> result = new List<UserScore>();
            if (position > ranking.Count)
            {
                throw new IndexOutOfRangeException();
            }
            var positionUserScore = ranking.OrderByDescending(x => x.Score).ElementAt(position - 1);

            result.Add(positionUserScore);
            result.AddRange(ranking.OrderBy(x => x.Score).Where(x => x.Score > positionUserScore.Score).Take(at));
            result.AddRange(ranking.OrderByDescending(x => x.Score).Where(x => x.Score < positionUserScore.Score).Take(at));

            return result.OrderBy(x => x.Score).ToList();
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

    }
}
