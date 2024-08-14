using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Roles;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RepositoryImpl
{
    public class RoleRepositoryImpl : IRolRepository
    {
        private readonly AppDbContext _context;

        public RoleRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Role> CreateRoleAsync(Role rol)
        {
            _context.Roles.Add(rol);
            await _context.SaveChangesAsync();
            return rol;
        }

       

        public async Task<Role> DeleteRolByIdAsync(int id)
        {
            // Buscar el rol por su ID
            var rol = await _context.Roles.FindAsync(id);

            // Verificar si el rol existe
            if (rol != null)
            {
                _context.Roles.Remove(rol); // Eliminar el rol
                await _context.SaveChangesAsync(); // Guardar los cambios
                return rol;
            }
            else
            {
                // Si el rol no existe, lanzar una excepción
                throw new Exception("El rol no existe");
            }



        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetRolByIdAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<Role> GetRolByNameAsync(string name)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Nombre == name);
        }

        public async  Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task UpdateRolAsync(Role rol)
        {
            _context.Roles.Update(rol);
            await _context.SaveChangesAsync();
        }





    }
}
