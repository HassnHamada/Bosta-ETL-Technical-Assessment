using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Receiver;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/Receiver")]
    public class ReceiverController : ControllerBase
    {
        private readonly IReceiverRepository _receiverRepository;
        public ReceiverController(IReceiverRepository receiverRepository)
        {
            _receiverRepository = receiverRepository;
        }
        [HttpGet("{id}", Name = "GetReceiverById")]
        public async Task<IActionResult> ReadAsync(int id)
        {
            var result = await _receiverRepository.ReadAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.ToReceiverGetDto());
        }
        [HttpGet("all")]
        public async Task<IActionResult> ReadAsync()
        {
            var result = await _receiverRepository.ReadAllAsync();
            var resultDto = result.Select(r => r.ToReceiverGetDto());
            return Ok(resultDto);
        }
        [HttpPost("new")]
        public async Task<IActionResult> CreateAsync([FromBody] ReceiverCreateDto receiverCreateDto)
        {
            var result = await _receiverRepository.CreateAsync(receiverCreateDto.ToReceiver());
            return CreatedAtRoute("GetReceiverById", new { id = result.Id }, result.ToReceiverGetDto());

        }
    }
}