using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IConfirmRepository
    {
        Task<Confirm> CreateAsync(Confirm confirm);
        Task<Confirm?> ReadAsync(int id);
        Task<Confirm?> UpdateAsync(int id, Confirm confirm);
        Task<Confirm?> DeleteAsync(int id);
    }
}