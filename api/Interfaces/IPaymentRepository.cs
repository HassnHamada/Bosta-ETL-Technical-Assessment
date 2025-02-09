using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payment> CreateAsync(Payment payment);
        Task<Payment?> ReadAsync(int id);
        Task<Payment?> UpdateAsync(int id, Payment payment);
        Task<Payment?> DeleteAsync(int id);
    }
}