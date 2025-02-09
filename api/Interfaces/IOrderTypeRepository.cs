using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IOrderTypeRepository
    {
        Task<OrderType> CreateAsync(OrderType orderType);
        Task<OrderType?> ReadAsync(int id);
        Task<OrderType?> ReadAsync(string type);
        Task<OrderType?> UpdateAsync(int id, OrderType orderType);
        Task<OrderType?> DeleteAsync(int id);
    }
}