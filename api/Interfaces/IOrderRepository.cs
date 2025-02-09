using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CreateAsync(Order order);
        Task<Order?> ReadAsync(int id);
        Task<Order?> UpdateAsync(int id, Order order);
        Task<Order?> DeleteAsync(int id);
    }
}