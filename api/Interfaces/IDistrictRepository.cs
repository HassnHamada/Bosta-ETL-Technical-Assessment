using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IDistrictRepository
    {
        Task<District> CreateAsync(District district);
        Task<District?> ReadAsync(int id);
        Task<District?> ReadAsync(string name);
        Task<District?> UpdateAsync(int id, District district);
        Task<District?> DeleteAsync(int id);
    }
}