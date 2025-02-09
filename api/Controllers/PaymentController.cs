using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Payment;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/Payment")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        [HttpGet("{id}", Name = "GetPaymentById")]
        public async Task<IActionResult> ReadAsync(int id)
        {
            var result = await _paymentRepository.ReadAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.ToPaymentGetDto());
        }

        [HttpPost("new")]
        public async Task<IActionResult> CreateAsync([FromBody] PaymentCreateDto paymentCreateDto)
        {
            var result = await _paymentRepository.CreateAsync(paymentCreateDto.ToPayment());
            return CreatedAtRoute("GetPaymentById", new { id = result.Id }, result.ToPaymentGetDto());
        }
    }
}