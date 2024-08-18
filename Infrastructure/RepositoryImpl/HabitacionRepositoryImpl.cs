using Domain.Models.Habitaciones;
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
    public class HabitacionRepositoryImpl:IHabitacionRepository
    {
        private readonly AppDbContext _context;

        public HabitacionRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Habitacion> CreateHabitacionAsync(Habitacion habitacion)
        {
            _context.Habitaciones.Add(habitacion);
            await _context.SaveChangesAsync();
            return habitacion;
        }

        public async Task<Habitacion> DeleteHabitacionAsync(int id)
        {
           var habitacion=_context.Habitaciones.Find(id);
            if (habitacion != null)
            {
                _context.Habitaciones.Remove(habitacion);
                _context.SaveChangesAsync();
                return await Task.FromResult(habitacion);
            }
            else
            {
                throw new Exception("La habitacion no existe");
            }
        }

        public async Task<IEnumerable<Habitacion>> GetAllHabitacionAsync()
        {
            return await _context.Habitaciones.ToListAsync();
        }

        public async Task<Habitacion> GetByIdHabitacionAsync(int id)
        {
            var habitacion = _context.Habitaciones.Find(id);
            if (habitacion != null)
            {
                return await Task.FromResult(habitacion);
            }
            else
            {
                throw new Exception("La habitacion no existe");
            }
        }

        public async Task<Habitacion> UpdateHabitacionAsync(Habitacion habitacion)
        {
           _context.Habitaciones.Update(habitacion);
            await _context.SaveChangesAsync();
            return habitacion;

        }
    }
}
