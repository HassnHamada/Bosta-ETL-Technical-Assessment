using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Address;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/Address")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly IZoneRepository _zoneRepository;
        public AddressController(IAddressRepository addressRepository, ICityRepository cityRepository, ICountryRepository countryRepository, IDistrictRepository districtRepository, IZoneRepository zoneRepository)
        {
            _addressRepository = addressRepository;
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
            _districtRepository = districtRepository;
            _zoneRepository = zoneRepository;
        }
        [HttpGet("{id}", Name = "GetAddressById")]
        public async Task<IActionResult> ReadAsync(int id)
        {
            var result = await _addressRepository.ReadAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.ToAddressGetDto());
        }

        [HttpPost("new")]
        public async Task<IActionResult> CreateAsync([FromBody] AddressCreateDto addressCreateDto)
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
            var result = await _addressRepository.CreateAsync(address);
            return CreatedAtRoute("GetAddressById", new { id = result.Id }, result.ToAddressGetDto());
        }
    }
}