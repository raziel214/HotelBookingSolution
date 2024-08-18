using Domain.Models.Hoteles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IHotelRepository
    {
        Task<Hotel> GetHotelByIdAsync(int id);
        Task<Hotel> GetHotelByCodeAsync(string code);
        Task<Hotel> GetHotelByNameAsync(string name);
        Task<Hotel> CreateHotelAsync(Hotel hotel);
        Task UpdateHotelAsync(int id,Hotel hotel);
        Task<Hotel> DeleteHotelByIdAsync(int id);
        Task<IEnumerable<Hotel>> GetAllHotelsAsync();
        Task<int> SaveChangesAsync();
    }
}
