using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IRolRepository
    {
        Task<Role> GetRolByIdAsync(int id);
        Task<Role> GetRolByNameAsync(string name);
        Task<Role> CreateRoleAsync(Role rol);
        Task UpdateRolAsync(Role rol);
        Task<Role> DeleteRolByIdAsync(int id);
        Task<IEnumerable<Role>> GetAllRolesAsync();
    }
}
