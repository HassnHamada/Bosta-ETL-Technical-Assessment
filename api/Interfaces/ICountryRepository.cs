using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface ICountryRepository
    {
        Task<Country> CreateAsync(Country country);
        Task<Country?> ReadAsync(int id);
        Task<Country?> ReadAsync(string name);
        Task<List<Country>> ReadAllAsync();
        Task<Country?> UpdateAsync(int id, Country country);
        Task<Country?> DeleteAsync(int id);
    }
}