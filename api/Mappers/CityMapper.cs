using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.City;
using api.Models;

namespace api.Mappers
{
    public static class CityMapper
    {
        public static City ToCity(this CityCreateDto cityCreateDto)
        {
            return new City
            {
                Name = cityCreateDto.Name
            };
        }

        public static CityGetDto ToCityGetDto(this City city)
        {
            return new CityGetDto
            {
                Id = city.Id,
                Name = city.Name
            };
        }
    }
}