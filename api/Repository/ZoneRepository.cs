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
    public class ZoneRepository : IZoneRepository
    {
        private readonly ApplicationDBContext _context;
        public ZoneRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Zone> CreateAsync(Zone zone)
        {
            await _context.Zone.AddAsync(zone);
            await _context.SaveChangesAsync();
            return zone;
        }

        public Task<Zone?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Zone?> ReadAsync(int id)
        {
            return await _context.Zone.SingleOrDefaultAsync(z => z.Id == id);
        }

        public async Task<Zone?> ReadAsync(string name)
        {
            return await _context.Zone.SingleOrDefaultAsync(z => z.Name == name);
        }

        public Task<Zone?> UpdateAsync(int id, Zone zone)
        {
            throw new NotImplementedException();
        }
    }
}