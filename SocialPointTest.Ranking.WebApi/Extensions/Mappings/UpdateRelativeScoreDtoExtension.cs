using System;

using SocialPointTest.Ranking.Domain.Entities;
using SocialPointTest.Ranking.WebApi.Models;

namespace SocialPointTest.Ranking.WebApi.Extensions.Mappings
{
    public static class UpdateRelativeScoreDtoExtension
    {
        public static UserScore MapToUserScore(this UpdateRelativeScoreDto updateRelativeScoreDto)
        {
            var dto = updateRelativeScoreDto ?? throw new ArgumentNullException(nameof(updateRelativeScoreDto));

            return new UserScore(new User { Id = updateRelativeScoreDto.UserId }, updateRelativeScoreDto.Score);
        }
    }
}