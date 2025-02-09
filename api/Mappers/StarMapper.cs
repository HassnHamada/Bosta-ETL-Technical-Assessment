using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Star;
using api.Models;

namespace api.Mappers
{
    public static class StarMapper
    {
        public static Star ToStar(this StarCreateDto starCreateDto)
        {
            return new Star
            {
                Name = starCreateDto.Name,
                Phone = starCreateDto.Phone
            };
        }

        public static StarGetDto ToStarGetDto(this Star star)
        {
            return new StarGetDto
            {
                Id = star.Id,
                Name = star.Name,
                Phone = star.Phone
            };
        }
    }
}