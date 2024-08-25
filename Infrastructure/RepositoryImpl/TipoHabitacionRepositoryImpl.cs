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

        public async Task<TiposHabitacion> CreateTipoHabitacionAsync(TiposHabitacion habitacion)
        {
            _context.TiposHabitaciones.Add(habitacion);
            await _context.SaveChangesAsync();
            return habitacion;
        }
        public async Task<TiposHabitacion> DeleteHabitacionTipoAsync(int id)
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
                throw new KeyNotFoundException("La habitación no existe");
            }
        }
        public async Task<IEnumerable<TiposHabitacion>> GetAllHabitacionTipoAsync()
        {
            return await _context.TiposHabitaciones.ToListAsync();
        }

        public async Task<TiposHabitacion> GetHabitacionTipoByIdAsync(int id)
        {
            var habitacion = await _context.TiposHabitaciones.FindAsync(id);
            if (habitacion == null)
            {
                throw new KeyNotFoundException("La habitación no existe");
            }
            return habitacion;
        }

        public async Task<TiposHabitacion> GetHabitacionTipoByNombreAsync(string nombre)
        {
            var habitacion = await _context.TiposHabitaciones.FirstOrDefaultAsync(h => h.Nombre == nombre);
            if (habitacion == null)
            {
                throw new KeyNotFoundException("La habitación no existe");
            }
            return habitacion;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task UpdateHabitacionTipoAsync(TiposHabitacion habitacion)
        {
            var entity = await _context.TiposHabitaciones.FindAsync(habitacion.IdTipoHabitacion);
            if (entity == null)
            {
                throw new KeyNotFoundException("La habitación no existe");
            }
            _context.TiposHabitaciones.Update(habitacion);
            await _context.SaveChangesAsync();
        }
    }
}
