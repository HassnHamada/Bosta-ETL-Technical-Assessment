using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface ICityRepository
    {
        Task<City> CreateAsync(City city);
        Task<City?> ReadAsync(int id);
        Task<City?> ReadAsync(string name);
        Task<List<City>> ReadAllAsync();
        Task<City?> UpdateAsync(int id, City city);
        Task<City?> DeleteAsync(int id);
    }
}