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
                new UserScore(new User{ Name = "Player2", Id=1}, 120),
                new UserScore(new User{ Name = "Player3", Id=1}, 360),
                new UserScore(new User{ Name = "Player4", Id=1}, 210),
                new UserScore(new User{ Name = "Player5", Id=1}, 564),
                new UserScore(new User{ Name = "Player6", Id=1}, 99),
                new UserScore(new User{ Name = "Player7", Id=1}, 670)
            };
        }

        public async Task<UserScore> GetUserScoreByUserIdAsync(int userId)
        {
            return await Task.FromResult(RankingList.FirstOrDefault(x => x.User.Id == userId));
        }

        public async Task<List<UserScore>> GetRankingAsync()
        {
            return await Task.FromResult(RankingList);
        }
    }
}
