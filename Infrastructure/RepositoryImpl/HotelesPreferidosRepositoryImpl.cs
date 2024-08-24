using Domain.Models.Hoteles;
using Domain.Models.HotelesPreferidos;
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
    public class HotelesPreferidosRepositoryImpl:IHotelesPreferidosRepository
    {
        private readonly AppDbContext _context;

        public HotelesPreferidosRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public async Task<HotelPreferido> CreateHotelPreferidoAsync(HotelPreferido hotelPreferido)
        {
            _context.HotelesPreferidos.Add(hotelPreferido);
            await _context.SaveChangesAsync();
            return hotelPreferido;
        }

        public async Task<HotelPreferido> DeleteHotelPreferidoByUserIdAsync(int idHotelPreferido)
        {
            var hotelPreferido = await GetHotelPreferidoByIdAsync(idHotelPreferido);
            
                if(hotelPreferido!=null)
                {
                   _context.HotelesPreferidos.Remove(hotelPreferido);
                    await _context.SaveChangesAsync();
                    return hotelPreferido;
                }
                else if(hotelPreferido==null)
                {
                    throw new KeyNotFoundException("El hotel preferido no existe");
                }
                else
                {
                    throw new Exception("Error al eliminar el hotel preferido");
                }
        }

        public async Task<IEnumerable<HotelPreferido>> GetAllHotelesPreferidosAsync()
        {
            return await _context.HotelesPreferidos.ToListAsync();
        }

        public async  Task<IEnumerable<HotelPreferido>> GetHotelesPreferidosByUserIdAsync(int userId)
        {
            var hotelPreferidos= await _context.HotelesPreferidos.Where(h => h.IdUsuario == userId).ToListAsync();
            if (hotelPreferidos.Count == 0)
            {
                throw new KeyNotFoundException("No se encontraron hoteles preferidos para el usuario");
            }
            return hotelPreferidos;
        }

        public async Task<HotelPreferido> GetHotelPreferidoByUserIdHotelIdAsync(int userId, int hotelId)
        {
            var hotelPreferido= await _context.HotelesPreferidos.FirstOrDefaultAsync(h => h.IdUsuario == userId && h.IdHotel == hotelId);
            if(hotelPreferido==null)
            {
                throw new KeyNotFoundException("No se encontro el hotel preferido");
            }
            return hotelPreferido;
        }

        public async Task<HotelPreferido> GetHotelPreferidoByIdAsync(int idHotelPreferido)
        {
            var hotelpreferido = await _context.HotelesPreferidos.FindAsync(idHotelPreferido);
            if (hotelpreferido == null)
            {
                throw new KeyNotFoundException("El hotel preferido no existe");
            }
            return hotelpreferido;
        }

        public async  Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task UpdateHotelPreferidoAsync(int userId, HotelPreferido hotelPreferido)
        {
            var hotelPreferidotemp = await GetHotelPreferidoByUserIdHotelIdAsync(userId, hotelPreferido.IdHotel);
            if(hotelPreferidotemp != null)
            {
                throw new KeyNotFoundException("El hotel preferido no existe");
            }
            _context.HotelesPreferidos.Update(hotelPreferido);
            await _context.SaveChangesAsync();

        }

        

        public async Task<HotelPreferido> DeleteHotelPreferidoByIdAsync(int idHotelPreferido)
        {
            var  hotelPreferido= await _context.HotelesPreferidos.FindAsync(idHotelPreferido);
            if (hotelPreferido != null)
            {
                _context.HotelesPreferidos.Remove(hotelPreferido);
                await _context.SaveChangesAsync();
                return hotelPreferido;
            }  
            else if(hotelPreferido==null)
            {
                throw new KeyNotFoundException("El hotel preferido no existe");
            }
            else
            {
                throw new Exception("Error al eliminar el hotel preferido");
            }
            
        }
    }
}
