using Domain.Models.Hoteles;
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
    public class HotelRepositoryImpl:IHotelRepository
    {
        private readonly AppDbContext _context;

        public HotelRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Hotel> CreateHotelAsync(Hotel hotel)
        {
            _context.Hoteles.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;

        }

        public async  Task<Hotel> DeleteHotelByIdAsync(int id)
        {
            var hotel = await _context.Hoteles.FindAsync(id);

            if (hotel != null)
            {
                _context.Hoteles.Remove(hotel);
                await _context.SaveChangesAsync();
                return hotel;
            }
            else
            {
                // Si el hotel no existe, lanzar una excepción
                throw new KeyNotFoundException("El hotel no existe");
            }
        }

        public async Task<IEnumerable<Hotel>> GetAllHotelsAsync()
        {
            return await _context.Hoteles.ToListAsync();
        }

        public async Task<Hotel> GetHotelByCodeAsync(string code)
        {
            var hotelCode= await _context.Hoteles.FirstOrDefaultAsync(h => h.Codigo == code);
            if (hotelCode == null)
            {
                throw new KeyNotFoundException("El hotel no existe");
            }
            return hotelCode;
        }

        public async  Task<Hotel> GetHotelByIdAsync(int id)
        {
            var hotel = await _context.Hoteles.FindAsync(id);
            if (hotel == null)
            {
                throw new KeyNotFoundException("El hotel no existe");
            }
            return hotel;
        }

        public async Task<Hotel> GetHotelByNameAsync(string name)
        {
            var hotelName = await _context.Hoteles.FirstOrDefaultAsync(h => h.Nombre == name);
            if(hotelName == null)
            {
                throw new KeyNotFoundException("El hotel no existe");
            }
            return hotelName;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task UpdateHotelAsync(int id, Hotel hotel)
        {
            var hotelExistente = await _context.Hoteles.FindAsync(id);
            if (hotelExistente == null)
            {
                throw new KeyNotFoundException("El hotel no existe");
            }
            _context.Hoteles.Update(hotel);
            await _context.SaveChangesAsync();
        }

        
    }
}
