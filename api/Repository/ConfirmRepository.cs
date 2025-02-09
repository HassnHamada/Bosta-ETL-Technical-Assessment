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
    public class ConfirmRepository : IConfirmRepository
    {
        private readonly ApplicationDBContext _context;
        public ConfirmRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Confirm> CreateAsync(Confirm confirm)
        {
            await _context.Confirm.AddAsync(confirm);
            await _context.SaveChangesAsync();
            return confirm;
        }

        public Task<Confirm?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Confirm>> ReadAllAsync()
        {
            return await _context.Confirm.ToListAsync();
        }

        public async Task<Confirm?> ReadAsync(int id)
        {
            return await _context.Confirm.SingleOrDefaultAsync(c => c.Id == id);
        }

        public Task<Confirm?> UpdateAsync(int id, Confirm confirm)
        {
            throw new NotImplementedException();
        }
    }
}