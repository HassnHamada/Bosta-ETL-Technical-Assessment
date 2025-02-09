using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.City;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/City")]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;
        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        [HttpGet("{id}", Name = "GetCityById")]
        public async Task<IActionResult> ReadAsync(int id)
        {
            var result = await _cityRepository.ReadAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.ToCityGetDto());
        }

        [HttpPost("new")]
        public async Task<IActionResult> CreateAsync([FromBody] CityCreateDto cityCreateDto)
        {
            var result = await _cityRepository.CreateAsync(cityCreateDto.ToCity());
            return CreatedAtRoute("GetCityById", new { id = result.Id }, result.ToCityGetDto());
        }
    }
}