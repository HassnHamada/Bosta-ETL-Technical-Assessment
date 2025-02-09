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
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDBContext _context;
        public CountryRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Country> CreateAsync(Country country)
        {
            await _context.Country.AddAsync(country);
            await _context.SaveChangesAsync();
            return country;        }

        public Task<Country?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Country?> ReadAsync(int id)
        {
            return await _context.Country.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Country?> ReadAsync(string name)
        {
            return await _context.Country.SingleOrDefaultAsync(c => c.Name == name);
        }

        public Task<Country?> UpdateAsync(int id, Country country)
        {
            throw new NotImplementedException();
        }
    }
}