using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Address;
using api.Interfaces;
using api.Mappers;
using api.Service;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/Address")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        private readonly AddressService _addressService;
        public AddressController(IAddressRepository addressRepository, AddressService addressService)
        {
            _addressRepository = addressRepository;
            _addressService = addressService;
        }
        [HttpGet("{id}", Name = "GetAddressById")]
        public async Task<IActionResult> ReadAsync(int id)
        {
            var result = await _addressRepository.ReadAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.ToAddressGetDto());
        }

        [HttpPost("new")]
        public async Task<IActionResult> CreateAsync([FromBody] AddressCreateDto addressCreateDto)
        {
            var address = await _addressService.NewAsync(addressCreateDto);
            var result = await _addressRepository.CreateAsync(address);
            return CreatedAtRoute("GetAddressById", new { id = result.Id }, result.ToAddressGetDto());
        }
    }
}