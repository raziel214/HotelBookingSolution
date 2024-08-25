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
            else if (habitacion == null)
            {
                throw new KeyNotFoundException("La habitacion no existe");
            }
            else 
            {
                throw new Exception("Error al eliminar la habitacion");
            }
        }

        public async Task<IEnumerable<Habitacion>> GetAllHabitacionAsync()
        {
            return await _context.Habitaciones.ToListAsync();
        }

        public async Task<Habitacion> GetByIdHabitacionAsync(int id)
        {
            var habitacion = await _context.Habitaciones.FindAsync(id);
            if (habitacion != null)
            {
                return await _context.Habitaciones.FindAsync(id);
            }
            else if (habitacion == null)
            {
                throw new KeyNotFoundException("La habitacion no existe");
            }
            else
            {
                throw new Exception("Error al obtener la habitacion");
            }
            
        }

        public async Task<Habitacion> GetHabitacionByCodeAsync(int code)
        {
            var habitacion = _context.Habitaciones.Where(h => h.NumeroHabitacion == code).FirstOrDefault();
            if (habitacion != null)
            {
                return await _context.Habitaciones.FindAsync(habitacion.IdHabitacion);
            }
            else if(habitacion==null)
            {
                throw new KeyNotFoundException("La habitacion no existe");
            }
            else
            {
                throw new Exception("Error al obtener la habitacion");
            }

        }


        public async  Task<IEnumerable<Habitacion>> GetHabitacionByHotelAsync(int hotelId)
        {
            var habitacion = await _context.Hoteles.FindAsync(hotelId);
            if (habitacion != null)
            {
                return await _context.Habitaciones
                .Where(h => h.IdHotel == hotelId)
                .ToListAsync();
            }
            else if (habitacion == null)
            {
                throw new KeyNotFoundException("El hotel no existe");
            }
            else
            {
                throw new Exception("Erro al obtener las habitaciones por hotel");
            }
        }

        public async Task<IEnumerable<Habitacion>> GetHabitacionByPriceAsync(int CostoBase)
        {
            var habitacion = await _context.Habitaciones
                .Where(h => h.CostoBase == CostoBase)
                .ToListAsync();
            if (habitacion != null)
            {
                return habitacion;
            }
            else if (habitacion == null)
            {
                throw new KeyNotFoundException("No hay habitaciones disponibles con ese precio");

            }
            else
            {
                throw new Exception("Error al obtener las habitaciones por precio");
            
            }
        }
        
        public async Task<IEnumerable<Habitacion>> GetHabitacionByStatusAndCapacityAsync(int Estado, int cantidadPersonas)
        {
            if (cantidadPersonas <= 3)
            {
                return await _context.Habitaciones
               .Where(h => h.Estado == Estado&& h.CantidadPersonas>=cantidadPersonas)
               .ToListAsync();
            }
            else if(cantidadPersonas>3) {
                throw new KeyNotFoundException("No hay habitaciones disponibles con esa capacidad");
            }
            else 
            {
                throw new Exception("Error al obtener las habitaciones por estado y capacidad");
            }
        }

        public async Task<IEnumerable<Habitacion>> GetHabitacionByTypeAsync(int type)
        {
            var habitacion = await _context.TiposHabitaciones.FindAsync(type);
            if (habitacion != null)
            {
                return await _context.Habitaciones
                .Where(h => h.IdTipoHabitacion == type)
                .ToListAsync();
            }
            else if (habitacion == null)
            {
                throw new KeyNotFoundException("No hay habitaciones disponibles con ese tipo de habitacion");
            }
            else
            {
                throw new Exception("Error al obtener habitaciones con ese tipo");
            }
        }

        public async  Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task UpdateHabitacionAsync(int id, Habitacion habitacion)
        {
            var habitaciontipo = await _context.TiposHabitaciones.FindAsync(habitacion.IdTipoHabitacion);
            if (habitacion != null)
            {
                _context.Habitaciones.Update(habitacion);
                await _context.SaveChangesAsync();
            }
            else if (habitacion == null)
            {
                throw new Exception("La habitacion  con ese id no existe");
            }
            else
            {
                throw new Exception("Error al actualizar la habitacion");
            }
                  
        }

        
    }
}
