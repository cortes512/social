using System;

using SocialPointTest.Ranking.Domain.Entities;
using SocialPointTest.Ranking.WebApi.Models;

namespace SocialPointTest.Ranking.WebApi.Extensions.Mappings
{
    public static class UpdateAbsoluteScoreDtoExtension
    {
        public static UserScore MapToUserScore(this UpdateAbsoluteScoreDto updateAbsoluteScoreDto)
        {
            var dto = updateAbsoluteScoreDto ?? throw new ArgumentNullException(nameof(updateAbsoluteScoreDto));

            return new UserScore(new User { Id = updateAbsoluteScoreDto.UserId }, updateAbsoluteScoreDto.TotalScore);
        }

    }
}