using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IZoneRepository
    {
        Task<Zone> CreateAsync(Zone zone);
        Task<Zone?> ReadAsync(int id);
        Task<Zone?> ReadAsync(string name);
        Task<List<Zone>> ReadAllAsync();
        Task<Zone?> UpdateAsync(int id, Zone zone);
        Task<Zone?> DeleteAsync(int id);
    }
}