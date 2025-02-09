using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Zone;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/Zone")]
    public class ZoneController : ControllerBase
    {
        private readonly IZoneRepository _zoneRepository;
        public ZoneController(IZoneRepository zoneRepository)
        {
            _zoneRepository = zoneRepository;
        }
        [HttpGet("{id}", Name = "GetZoneById")]
        public async Task<IActionResult> ReadAsync(int id)
        {
            var result = await _zoneRepository.ReadAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.ToZoneGetDto());
        }
        [HttpGet("all")]
        public async Task<IActionResult> ReadAsync()
        {
            var result = await _zoneRepository.ReadAllAsync();
            var resultDto = result.Select(z => z.ToZoneGetDto());
            return Ok(resultDto);
        }
        [HttpPost("new")]
        public async Task<IActionResult> CreateAsync([FromBody] ZoneCreateDto zoneCreateDto)
        {
            var result = await _zoneRepository.CreateAsync(zoneCreateDto.ToZone());
            return CreatedAtRoute("GetZoneById", new { id = result.Id }, result.ToZoneGetDto());
        }
    }
}