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
             var idTipoHabitacion = await _context.TiposHabitaciones.FindAsync(habitacion.IdTipoHabitacion);
             var idHotel = await _context.Hoteles.FindAsync(habitacion.IdHotel);
            if (idTipoHabitacion == null)
            {
                throw new Exception("El tipo de habitacion no existe");
            }
            if (idHotel == null)
            {
                throw new Exception("El hotel no existe");
            }
            _context.Habitaciones.Add(habitacion);
            await _context.SaveChangesAsync();
            return habitacion;
        }

        public async Task<Habitacion> DeleteHabitacionByIdAsync(int id)
        {
           var habitacion=await _context.Habitaciones.FindAsync(id);
            if (habitacion != null)
            {
                _context.Habitaciones.Remove(habitacion);
                await _context.SaveChangesAsync();
                return habitacion;
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
            return await _context.Habitaciones.FindAsync(id);
        }

        public async Task<Habitacion> GetHabitacionByCodeAsync(int code)
        {
            var habitacion = _context.Habitaciones.Where(h => h.NumeroHabitacion == code).FirstOrDefault();
            if (habitacion != null)
            {
                return await _context.Habitaciones.FindAsync(habitacion.IdHabitacion);
            }
            else
            {
                throw new Exception("La habitacion no existe");
            }

        }


        public async  Task<IEnumerable<Habitacion>> GetHabitacionByHotelAsync(int hotelId)
        {
            return await _context.Habitaciones
                .Where(h => h.IdHotel == hotelId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Habitacion>> GetHabitacionByPriceAsync(int CostoBase)
        {
            return await _context.Habitaciones
                     .Where(h => h.CostoBase == CostoBase)
                     .ToListAsync();
        }

        public async Task<IEnumerable<Habitacion>> GetHabitacionByStatusAsync(int Estado)
        {
            return await _context.Habitaciones
                .Where(h => h.Estado == Estado)
                .ToListAsync();
        }

        public async Task<IEnumerable<Habitacion>> GetHabitacionByTypeAsync(int type)
        {
            return await _context.Habitaciones
                .Where(h => h.IdTipoHabitacion == type)
                .ToListAsync();
        }

        public async  Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task UpdateHabitacionAsync(int id, Habitacion habitacion)
        {
          _context.Habitaciones.Update(habitacion);
            await _context.SaveChangesAsync();          
        }

        
    }
}
