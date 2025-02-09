using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IAddressRepository
    {
        Task<Address> CreateAsync(Address address);
        Task<Address?> ReadAsync(int id);
        Task<List<Address>> ReadAllAsync();
        Task<Address?> UpdateAsync(int id, Address address);
        Task<Address?> DeleteAsync(int id);
    }
}