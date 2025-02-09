using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Confirm;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/Confirm")]
    public class ConfirmController: ControllerBase
    {
        private readonly IConfirmRepository _confirmRepository;
        public ConfirmController(IConfirmRepository confirmRepository)
        {
            _confirmRepository = confirmRepository;
        }
        [HttpGet("{id}", Name = "GetConfirmById")]
        public async Task<IActionResult> ReadAsync(int id)
        {
            var result = await _confirmRepository.ReadAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.ToConfirmGetDto());
        }
        [HttpGet("all")]
        public async Task<IActionResult> ReadAsync()
        {
            var result = await _confirmRepository.ReadAllAsync();
            var resultDto = result.Select(c => c.ToConfirmGetDto());
            return Ok(resultDto);
        }
        [HttpPost("new")]
        public async Task<IActionResult> CreateAsync([FromBody] ConfirmCreateDto confirmCreateDto)
        {
            var result = await _confirmRepository.CreateAsync(confirmCreateDto.ToConfirm());
            return CreatedAtRoute("GetConfirmById", new { id = result.Id }, result.ToConfirmGetDto());
        }
    }
}