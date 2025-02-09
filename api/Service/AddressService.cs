using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Address;
using api.Interfaces;
using api.Mappers;
using api.Models;

namespace api.Service
{
    public class AddressService
    {
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly IZoneRepository _zoneRepository;
        public AddressService(ICityRepository cityRepository, ICountryRepository countryRepository, IDistrictRepository districtRepository, IZoneRepository zoneRepository)
        {
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
            _districtRepository = districtRepository;
            _zoneRepository = zoneRepository;
        }

        public async Task<Address> NewAsync(AddressCreateDto addressCreateDto)
        {
            var city = await _cityRepository.ReadAsync(addressCreateDto.City.Name);
            var country = await _countryRepository.ReadAsync(addressCreateDto.Country.Name);
            var district = await _districtRepository.ReadAsync(addressCreateDto.District.Name);
            var zone = await _zoneRepository.ReadAsync(addressCreateDto.Zone.Name);
            if (city == null)
            {
                city = await _cityRepository.CreateAsync(addressCreateDto.City.ToCity());
            }
            if (country == null)
            {
                country = await _countryRepository.CreateAsync(addressCreateDto.Country.ToCountry());
            }
            if (district == null)
            {
                district = await _districtRepository.CreateAsync(addressCreateDto.District.ToDistrict());
            }
            if (zone == null)
            {
                zone = await _zoneRepository.CreateAsync(addressCreateDto.Zone.ToZone());
            }
            var address = addressCreateDto.ToAddress(city.Id, country.Id, district.Id, zone.Id);
            return address;
        }
    }
}