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

        public async Task<HotelPreferido> CreateHotelPreferidoAsync(int userId, int hotelId)
        {
            _context.HotelesPreferidos.Add(new HotelPreferido { IdUsuario = userId, IdHotel = hotelId });
            await _context.SaveChangesAsync();
            return await GetHotelPreferidoByUserIdHotelIdAsync(userId, hotelId);
        }

        public async Task<HotelPreferido> DeleteHotelPreferidoByUserIdAsync(int idHotelPreferido)
        {
            var hotelPreferido = await GetHotelPreferidoByIdAsync(idHotelPreferido);
            if (hotelPreferido != null)
            {
                _context.HotelesPreferidos.Remove(hotelPreferido);
                await _context.SaveChangesAsync();
            }
            return hotelPreferido;
            
        }

        public async Task<IEnumerable<HotelPreferido>> GetAllHotelesPreferidosAsync()
        {
            return await _context.HotelesPreferidos.ToListAsync();
        }

        public async  Task<IEnumerable<HotelPreferido>> GetHotelesPreferidosByUserIdAsync(int userId)
        {
            return await _context.HotelesPreferidos.Where(h => h.IdUsuario == userId).ToListAsync();
        }

        public Task<HotelPreferido> GetHotelPreferidoByUserIdHotelIdAsync(int userId, int hotelId)
        {
            return _context.HotelesPreferidos.FirstOrDefaultAsync(h => h.IdUsuario == userId && h.IdHotel == hotelId);
        }

        public async Task<HotelPreferido> GetHotelPreferidoByIdAsync(int idHotelPreferido)
        {
            return await _context.HotelesPreferidos.FindAsync(idHotelPreferido);
        }

        public async  Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task UpdateHotelPreferidoAsync(int userId, int hotelId)
        {
            _context.HotelesPreferidos.Update(new HotelPreferido { IdUsuario = userId, IdHotel = hotelId });
            await _context.SaveChangesAsync();
        }
    }
}
