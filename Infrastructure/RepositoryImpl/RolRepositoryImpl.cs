using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repository;

namespace Infrastructure.RepositoryImpl
{
    internal class RolRepositoryImpl : IRolRepostitory
    {
        private readonly AppDbContext _context;

        public RolRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Rol> AddRolAsync(Rol rol)
        {
            await _context.Roles.AddAsync(rol);
            await _context.SaveChangesAsync();
            return rol;
        }



    }
}
