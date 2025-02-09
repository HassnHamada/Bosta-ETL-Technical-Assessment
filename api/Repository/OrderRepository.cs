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
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDBContext _context;
        public OrderRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Order> CreateAsync(Order order)
        {
            await _context.Order.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public Task<Order?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Order?> ReadAsync(int id)
        {
            return await _context.Order.SingleOrDefaultAsync(o => o.Id == id);
        }

        public Task<Order?> UpdateAsync(int id, Order order)
        {
            throw new NotImplementedException();
        }
    }
}