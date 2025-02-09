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
    public class DistrictRepository : IDistrictRepository
    {
        private readonly ApplicationDBContext _context;
        public DistrictRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<District> CreateAsync(District district)
        {
            await _context.District.AddAsync(district);
            await _context.SaveChangesAsync();
            return district;
        }

        public Task<District?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<District>> ReadAllAsync()
        {
            return await _context.District.OrderBy(d => d.Id).ToListAsync();
        }

        public async Task<District?> ReadAsync(int id)
        {
            return await _context.District.SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task<District?> ReadAsync(string name)
        {
            return await _context.District.SingleOrDefaultAsync(d => d.Name == name);
        }

        public Task<District?> UpdateAsync(int id, District district)
        {
            throw new NotImplementedException();
        }
    }
}