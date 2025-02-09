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
    public class ReceiverRepository : IReceiverRepository
    {
        private readonly ApplicationDBContext _context;
        public ReceiverRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Receiver> CreateAsync(Receiver receiver)
        {
            await _context.Receiver.AddAsync(receiver);
            await _context.SaveChangesAsync();
            return receiver;
        }

        public Task<Receiver?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Receiver?> ReadAsync(int id)
        {
            return await _context.Receiver.SingleOrDefaultAsync(r => r.Id == id);
        }

        public Task<Receiver?> UpdateAsync(int id, Receiver receiver)
        {
            throw new NotImplementedException();
        }
    }
}