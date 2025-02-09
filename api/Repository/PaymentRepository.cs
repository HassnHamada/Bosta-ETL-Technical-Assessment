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
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDBContext _context;
        public PaymentRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Payment> CreateAsync(Payment payment)
        {
            await _context.Payment.AddAsync(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public Task<Payment?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Payment?> ReadAsync(int id)
        {
            return await _context.Payment.SingleOrDefaultAsync(p => p.Id == id);
        }

        public Task<Payment?> UpdateAsync(int id, Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}