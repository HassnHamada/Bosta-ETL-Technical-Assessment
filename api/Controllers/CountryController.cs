using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Country;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/Country")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        [HttpGet("{id}", Name = "GetCountryById")]
        public async Task<IActionResult> ReadAsync(int id)
        {
            var result = await _countryRepository.ReadAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.ToCountryGetDto());
        }

        [HttpPost("new")]
        public async Task<IActionResult> CreateAsync([FromBody] CountryCreateDto countryCreateDto)
        {
            var result = await _countryRepository.CreateAsync(countryCreateDto.ToCountry());
            return CreatedAtRoute("GetCountryById", new { id = result.Id }, result.ToCountryGetDto());
        }
    }
}