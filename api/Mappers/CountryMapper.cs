using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Country;
using api.Models;

namespace api.Mappers
{
    public static class CountryMapper
    {

        public static Country ToCountry(this CountryCreateDto cityCreateDto)
        {
            return new Country
            {
                Name = cityCreateDto.Name
            };
        }

        public static CountryGetDto ToCountryGetDto(this Country city)
        {
            return new CountryGetDto
            {
                Id = city.Id,
                Name = city.Name
            };
        }
    }
}