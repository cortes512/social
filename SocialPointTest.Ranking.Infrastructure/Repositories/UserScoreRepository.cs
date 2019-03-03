using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SocialPointTest.Ranking.Domain.Entities;
using SocialPointTest.Ranking.Domain.Repositories;


namespace SocialPointTest.Ranking.Infrastructure.Repositories
{
    public class UserScoreRepository : IUserScore
    {
        public List<UserScore> RankingList;

        public UserScoreRepository()
        {
            RankingList = new List<UserScore> {
                new UserScore(new User{ Name = "Player1", Id=1}, 250),
                new UserScore(new User{ Name = "Player2", Id=2}, 120),
                new UserScore(new User{ Name = "Player3", Id=3}, 360),
                new UserScore(new User{ Name = "Player4", Id=4}, 210),
                new UserScore(new User{ Name = "Player5", Id=5}, 564),
                new UserScore(new User{ Name = "Player6", Id=6}, 99),
                new UserScore(new User{ Name = "Player7", Id=7}, 670)
            };
        }

        public async Task<UserScore> GetUserScoreByUserIdAsync(int userId)
        {
            return await Task.FromResult(RankingList.FirstOrDefault(x => x.User.Id == userId));
        }

        public async Task<List<UserScore>> GetRankingAsync(int top)
        {
            return await Task.FromResult(RankingList.OrderByDescending(x => x.Score).Take(top).ToList());
        }

        public void UpdateAbsoluteScore(int userId, int newScore)
        {
            var userScore = RankingList.Single(x => x.User.Id == userId);
            userScore.Score = newScore;
        }

        public void UpdateRelativeScore(int userId, int score)
        {
            var userScore = RankingList.Single(x => x.User.Id == userId);
            userScore.Score += score;
        }
    }
}
