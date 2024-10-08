﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos.Roles;
using Domain.Models.Roles;

namespace Application.Service.Roles
{
    public interface IRoleService
    {
        Task<Role> GetRoleByIdAsync(int id);
        Task<Role> GetRoleByNameAsync(string name);
        Task<RoleRead> CreateRoleAsync(RoleCreate role);
        Task UpdateRoleAsync(int id,Role role);
        Task<Role> DeleteRoleByIdAsync(int id);
        Task<IEnumerable<Role>> GetAllRolesAsync();

    }
}
