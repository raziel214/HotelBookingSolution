using Domain.Models.TiposHabitaciones;
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
    public class TipoHabitacionRepositoryImpl: ITipoHabitacionRepository
    {
        private readonly AppDbContext _context;

        public TipoHabitacionRepositoryImpl(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<TiposHabitacion> CreateHabitacionAsync(TiposHabitacion habitacion)
        {
            _context.TiposHabitaciones.Add(habitacion);
            await _context.SaveChangesAsync();
            return habitacion;
        }
        public async Task<TiposHabitacion> DeleteHabitacionAsync(int id)
        {
            var habitacion = await _context.TiposHabitaciones.FindAsync(id);
            if (habitacion != null)
            {
                _context.TiposHabitaciones.Remove(habitacion);
                await _context.SaveChangesAsync();
                return habitacion;
            }
            else
            {
                throw new Exception("La habitación no existe");
            }
        }
        public async Task<IEnumerable<TiposHabitacion>> GetAllHabitacionAsync()
        {
            return await _context.TiposHabitaciones.ToListAsync();
        }

        public async Task<TiposHabitacion> GetHabitacionByIdAsync(int id)
        {
            return await _context.TiposHabitaciones.FindAsync(id);
        }

        public async Task<TiposHabitacion> GetHabitacionByNombreAsync(string nombre)
        {
            return await _context.TiposHabitaciones.FirstOrDefaultAsync(h => h.Nombre == nombre);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task UpdateHabitacionAsync(TiposHabitacion habitacion)
        {
            _context.TiposHabitaciones.Update(habitacion);
            await _context.SaveChangesAsync();
        }
    }
}
