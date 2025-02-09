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
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDBContext _context;
        public CityRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<City> CreateAsync(City city)
        {
            await _context.City.AddAsync(city);
            await _context.SaveChangesAsync();
            return city;
        }

        public Task<City?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<City>> ReadAllAsync()
        {
            return await _context.City.OrderBy(c => c.Id).ToListAsync();
        }

        public async Task<City?> ReadAsync(int id)
        {
            return await _context.City.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<City?> ReadAsync(string name)
        {
            return await _context.City.SingleOrDefaultAsync(c => c.Name == name);
        }

        public Task<City?> UpdateAsync(int id, City city)
        {
            throw new NotImplementedException();
        }
    }
}