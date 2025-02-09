using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IStarRepository
    {
        Task<Star> CreateAsync(Star star);
        Task<Star?> ReadAsync(int id);
        Task<List<Star>> ReadAllAsync();
        Task<Star?> UpdateAsync(int id, Star star);
        Task<Star?> DeleteAsync(int id);
    }
}