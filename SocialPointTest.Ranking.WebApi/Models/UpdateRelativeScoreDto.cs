using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialPointTest.Ranking.WebApi.Models
{
    public class UpdateRelativeScoreDto
    {
        public int UserId { get; set; }
        public int Score { get; set; }
    }
}