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
    public class StarRepository : IStarRepository
    {
        private readonly ApplicationDBContext _context;
        public StarRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Star> CreateAsync(Star star)
        {
            await _context.Star.AddAsync(star);
            await _context.SaveChangesAsync();
            return star;
        }

        public Task<Star?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Star>> ReadAllAsync()
        {
            return await _context.Star.ToListAsync();
        }

        public async Task<Star?> ReadAsync(int id)
        {
            return await _context.Star.SingleOrDefaultAsync(s => s.Id == id);
        }

        public Task<Star?> UpdateAsync(int id, Star star)
        {
            throw new NotImplementedException();
        }
    }
}