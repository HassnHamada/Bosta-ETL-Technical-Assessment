using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Star;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/Star")]
    public class StarController : ControllerBase
    {
        private readonly IStarRepository _starRepository;
        public StarController(IStarRepository starRepository)
        {
            _starRepository = starRepository;
        }
        [HttpGet("{id}", Name = "GetStarById")]
        public async Task<IActionResult> ReadAsync(int id)
        {
            var result = await _starRepository.ReadAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.ToStarGetDto());
        }
        [HttpGet("all")]
        public async Task<IActionResult> ReadAsync()
        {
            var result = await _starRepository.ReadAllAsync();
            var resultDto = result.Select(s => s.ToStarGetDto());
            return Ok(resultDto);
        }
        [HttpPost("new")]
        public async Task<IActionResult> CreateAsync([FromBody] StarCreateDto starCreateDto)
        {
            var result = await _starRepository.CreateAsync(starCreateDto.ToStar());
            return CreatedAtRoute("GetStarById", new { id = result.Id }, result.ToStarGetDto());
        }
    }
}