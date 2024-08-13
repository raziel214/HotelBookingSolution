using Application.Dtos.Roles;
using AutoMapper;
using Domain.Models;
using Domain.Models.Roles;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Roles
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IRolRepository _rolRepository;

        public RoleService(IMapper mapper, IRolRepository rolRepository)
        {
            _mapper = mapper;
            _rolRepository = rolRepository;
        }

        public async Task<RoleRead> CreateRoleAsync(RoleCreate role)
        {
            Role entity = _mapper.Map<Role>(role);
            entity = await _rolRepository.CreateRoleAsync(entity);
            RoleRead dto = _mapper.Map<RoleRead>(entity);
            return dto;
        }

        public Task<Role> DeleteRoleByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _rolRepository.GetAllRolesAsync();
        }

        public async  Task<Role> GetRoleByIdAsync(int id)
        {
            return await _rolRepository.GetRolByIdAsync(id);
        }

        public async  Task<Role> GetRoleByNameAsync(string name)
        {
            return await _rolRepository.GetRolByNameAsync(name);
        }

        public async Task UpdateRoleAsync(Role role)
        {
            await _rolRepository.UpdateRolAsync(role);
        }
    } 
}
