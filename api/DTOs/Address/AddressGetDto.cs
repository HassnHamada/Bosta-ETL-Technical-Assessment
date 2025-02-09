using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Address
{
    public class AddressGetDto
    {
        public required int Id { get; set; }
        public required int Floor { get; set; }
        public required int Apartment { get; set; }
        public required string FirstLine { get; set; }
        public required string Secondline { get; set; }
        public required float Latitude { get; set; }
        public required float Longitude { get; set; }
        public required int DistrictId { get; set; }
        public required int CityId { get; set; }
        public required int ZoneId { get; set; }
        public required int CountryId { get; set; }
    }
}