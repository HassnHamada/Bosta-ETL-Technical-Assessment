using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Context;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDBContext _context;
        public AddressRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Address> CreateAsync(Address address)
        {
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public Task<Address?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Address>> ReadAllAsync()
        {
            return await _context.Addresses.OrderBy(a => a.Id).ToListAsync();
        }

        public async Task<Address?> ReadAsync(int id)
        {
            return await _context.Addresses.SingleOrDefaultAsync(a => a.Id == id);
        }

        public Task<Address?> UpdateAsync(int id, Address address)
        {
            throw new NotImplementedException();
        }
    }
}