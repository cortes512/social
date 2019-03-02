using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPointTest.Ranking.Domain.Entities
{
    public class UserScore
    {
        public User User { get; set; }
        public int Score { get; set; }

        public UserScore(User user, int score)
        {
            this.User = user;
            this.Score = score;
        }
    }
}
