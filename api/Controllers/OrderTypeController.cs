using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.OrderType;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/OrderType")]
    public class OrderTypeController : ControllerBase
    {
        private readonly IOrderTypeRepository _orderTypeRepository;
        public OrderTypeController(IOrderTypeRepository orderTypeRepository)
        {
            _orderTypeRepository = orderTypeRepository;
        }
        [HttpGet("{id}", Name = "GetOrderTypeById")]
        public async Task<IActionResult> ReadAsync(int id)
        {
            var result = await _orderTypeRepository.ReadAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.ToOrderTypeGetDto());
        }
        [HttpGet("all")]
        public async Task<IActionResult> ReadAsync()
        {
            var result = await _orderTypeRepository.ReadAllAsync();
            var resultDto = result.Select(ot => ot.ToOrderTypeGetDto());
            return Ok(resultDto);
        }
        [HttpPost("new")]
        public async Task<IActionResult> CreateAsync([FromBody] OrderTypeCreateDto orderTypeCreateDto)
        {
            var result = await _orderTypeRepository.CreateAsync(orderTypeCreateDto.ToOrderType());
            return CreatedAtRoute("GetOrderTypeById", new { id = result.Id }, result.ToOrderTypeGetDto());
        }
    }
}