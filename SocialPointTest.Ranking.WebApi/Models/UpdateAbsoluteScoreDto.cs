using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialPointTest.Ranking.WebApi.Models
{
    public class UpdateAbsoluteScoreDto
    {
        public int UserId { get; set; }
        public int TotalScore { get; set; }
    }
}