
using Domain.Models.HotelesPreferidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IHotelesPreferidosRepository
    {
        Task<IEnumerable<HotelPreferido>> GetHotelesPreferidosByUserIdAsync(int userId);
        Task<HotelPreferido> GetHotelPreferidoByIdAsync(int idHotelPreferido);
        Task<HotelPreferido> GetHotelPreferidoByUserIdHotelIdAsync(int userId, int hotelId);
        Task<HotelPreferido> CreateHotelPreferidoAsync(HotelPreferido hotelPreferido);
        Task UpdateHotelPreferidoAsync(int userId, int hotelId);
        Task<HotelPreferido> DeleteHotelPreferidoByIdAsync(int idHotelPreferido);
        Task<IEnumerable<HotelPreferido>> GetAllHotelesPreferidosAsync();
        Task<int> SaveChangesAsync();
    }
}
