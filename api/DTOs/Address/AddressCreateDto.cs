using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.City;
using api.DTOs.Country;
using api.DTOs.District;
using api.DTOs.Zone;

namespace api.DTOs.Address
{
    public class AddressCreateDto
    {
        public required int Floor { get; set; }
        public required int Apartment { get; set; }
        public required string FirstLine { get; set; }
        public required string Secondline { get; set; }
        public required float latitude { get; set; }
        public required float longitude { get; set; }
        public required DistrictCreateDto District { get; set; }
        public required CityCreateDto City { get; set; }
        public required ZoneCreateDto Zone { get; set; }
        public required CountryCreateDto Country { get; set; }
    }
}