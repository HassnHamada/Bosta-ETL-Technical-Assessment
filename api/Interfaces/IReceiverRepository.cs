using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IReceiverRepository
    {
        Task<Receiver> CreateAsync(Receiver receiver);
        Task<Receiver?> ReadAsync(int id);
        Task<Receiver?> UpdateAsync(int id, Receiver receiver);
        Task<Receiver?> DeleteAsync(int id);
    }
}