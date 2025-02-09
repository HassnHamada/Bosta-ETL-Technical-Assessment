using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Order;
using api.Interfaces;
using api.Mappers;
using api.Models;
using api.Service;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/Order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly OrderService _orderService;
        public OrderController(IOrderRepository orderRepository, OrderService orderService)
        {
            _orderRepository = orderRepository;
            _orderService = orderService;
        }
        [HttpGet("{id}", Name = "GetOrderById")]
        public async Task<IActionResult> ReadAsync(int id)
        {
            var result = await _orderRepository.ReadAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.ToOrderGetDto());
        }
        [HttpGet("all")]
        public async Task<IActionResult> ReadAsync()
        {
            var result = await _orderRepository.ReadAllAsync();
            var resultDto = result.Select(o => o.ToOrderGetDto());
            return Ok(resultDto);
        }

        [HttpPost("new")]
        public async Task<IActionResult> CreateAsync([FromBody] OrderCreateDto orderCreateDto)
        {
            var order = await _orderService.NewAsync(orderCreateDto);
            var result = await _orderRepository.CreateAsync(order);
            return CreatedAtRoute("GetOrderById", new { id = result.Id }, result.ToOrderGetDto());
        }
    }
}