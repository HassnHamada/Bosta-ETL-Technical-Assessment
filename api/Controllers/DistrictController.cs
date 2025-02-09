using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.District;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/District")]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictRepository _districtRepository;
        public DistrictController(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }
        [HttpGet("{id}", Name = "GetDistrictById")]
        public async Task<IActionResult> ReadAsync(int id)
        {
            var result = await _districtRepository.ReadAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.ToDistrictGetDto());
        }
        [HttpGet("all")]
        public async Task<IActionResult> ReadAsync()
        {
            var result = await _districtRepository.ReadAllAsync();
            var resultDto = result.Select(d => d.ToDistrictGetDto());
            return Ok(resultDto);
        }
        [HttpPost("new")]
        public async Task<IActionResult> CreateAsync([FromBody] DistrictCreateDto districtCreateDto)
        {
            var result = await _districtRepository.CreateAsync(districtCreateDto.ToDistrict());
            return CreatedAtRoute("GetDistrictById", new { id = result.Id }, result.ToDistrictGetDto());
        }
    }
}