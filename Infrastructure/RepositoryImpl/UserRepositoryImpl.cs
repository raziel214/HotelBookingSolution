using Domain.Models.Users;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryImpl
{
    public class UserRepositoryImpl:IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public async  Task<User> CreateUserAsync(User user)
        {
            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

       

        public async Task<User> DeleteUserByIdAsync(int id)
        {
            // Buscar el usuario por su ID
            var usuario = await _context.Usuarios.FindAsync(id);
            // Verificar si el usuario existe
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario); // Eliminar el usuario
                await _context.SaveChangesAsync(); // Guardar los cambios
                return usuario;
            }
            else
            {
                // Si el usuario no existe, lanzar una excepción
                throw new KeyNotFoundException("El usuario no existe");
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
           var users = await _context.Usuarios.Include(u => u.Rol).ToListAsync();
            if (users == null)
            {
                throw new KeyNotFoundException("No hay usuarios registrados");
            }
            return users;
        }

        public async  Task<User> GetUserByEmailAsync(string email)
        {
           var user =await _context.Usuarios.Include(u => u.Rol).FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                throw new KeyNotFoundException("El usuario no existe");
            }
            return user;
        }

        public async  Task<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Usuarios.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException("El usuario no existe");
            }
            return user;
        }

        public async Task<User> GetUserByUserNameAndEmailAndPasswordAsync( string email, string password)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u =>  u.Email == email && u.Password == password);
        }


       

        public async Task<int> SaveChangesAsync()
        {
           return await _context.SaveChangesAsync();
        }

        public async  Task UpdateUserAsync(User user)
        {
           var entity = await _context.Usuarios.FindAsync(user.Id);
            if (entity == null)
            {
                throw new KeyNotFoundException("El usuario no existe");
            }
            _context.Usuarios.Update(user);
            await _context.SaveChangesAsync();  
        }
    }
}
