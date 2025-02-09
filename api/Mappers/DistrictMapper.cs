using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.District;
using api.Models;

namespace api.Mappers
{
    public static class DistrictMapper
    {

        public static District ToDistrict(this DistrictCreateDto districtCreateDto)
        {
            return new District
            {
                Name = districtCreateDto.Name
            };
        }

        public static DistrictGetDto ToDistrictGetDto(this District district)
        {
            return new DistrictGetDto
            {
                Id = district.Id,
                Name = district.Name
            };
        }
    }
}