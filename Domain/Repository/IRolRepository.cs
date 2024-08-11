using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    internal interface IRolRepository
    {
        Task<Rol> GetRolByIdAsync(int id);
        Task<Rol> GetRolByNameAsync(string name);
        Task<Rol> AddRolAsync(Rol rol);
        Task<Rol> UpdateRolAsync(Rol rol);
        Task<Rol> DeleteRolAsync(Rol rol);
        Task<Rol> DeleteRolByIdAsync(int id);
        Task<IEnumerable<Rol>> GetAllRolesAsync();
    }
}
