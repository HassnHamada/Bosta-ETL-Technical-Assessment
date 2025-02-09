using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Address;
using api.Models;

namespace api.Mappers
{
    public static class AddressMapper
    {
        public static Address ToAddress(this AddressCreateDto addressCreateDto, int cityId, int countryId, int districtId, int zoneId)
        {
            return new Address
            {
                Floor = addressCreateDto.Floor,
                Apartment = addressCreateDto.Apartment,
                FirstLine = addressCreateDto.FirstLine,
                Secondline = addressCreateDto.Secondline,
                Latitude = addressCreateDto.Latitude,
                Longitude = addressCreateDto.Longitude,
                DistrictId = districtId,
                CityId = cityId,
                CountryId = countryId,
                ZoneId = zoneId
            };
        }

        public static AddressGetDto ToAddressGetDto(this Address address)
        {
            return new AddressGetDto
            {
                Id = address.Id,
                Floor = address.Floor,
                Apartment = address.Apartment,
                FirstLine = address.FirstLine,
                Secondline = address.Secondline,
                Latitude = address.Latitude,
                Longitude = address.Longitude,
                DistrictId = address.DistrictId,
                CityId = address.CityId,
                CountryId = address.CountryId,
                ZoneId = address.ZoneId
            };
        }
    }
}