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
    public class OrderTypeRepository : IOrderTypeRepository
    {
        private readonly ApplicationDBContext _context;
        public OrderTypeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<OrderType> CreateAsync(OrderType orderType)
        {
            await _context.OrderTypes.AddAsync(orderType);
            await _context.SaveChangesAsync();
            return orderType;
        }

        public Task<OrderType?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderType>> ReadAllAsync()
        {
            return await _context.OrderTypes.OrderBy(ot => ot.Id).ToListAsync();
        }

        public async Task<OrderType?> ReadAsync(int id)
        {
            return await _context.OrderTypes.SingleOrDefaultAsync(ot => ot.Id == id);
        }

        public async Task<OrderType?> ReadAsync(string type)
        {
            return await _context.OrderTypes.SingleOrDefaultAsync(ot => ot.Type == type);
        }

        public Task<OrderType?> UpdateAsync(int id, OrderType orderType)
        {
            throw new NotImplementedException();
        }
    }
}