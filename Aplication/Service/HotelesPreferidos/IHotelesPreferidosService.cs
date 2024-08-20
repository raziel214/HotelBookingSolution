using Aplication.Dtos.HotelesPreferidos;
using Domain.Models.HotelesPreferidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Service.HotelesPreferidos
{
    public interface IHotelesPreferidosService
    {
        Task<IEnumerable<HotelPreferido>> GetHotelesPreferidosByUserIdAsync(int userId);
        Task<HotelPreferido> GetHotelPreferidoByIdAsync(int idHotelPreferido);
        Task<HotelPreferido> GetHotelPreferidoByUserIdHotelIdAsync(int userId, int hotelId);
        Task<HotelPreferidoRead> CreateHotelPreferidoAsync(HotelPreferidoCreate hotelPreferidoCreate);
        Task UpdateHotelPreferidoAsync(int IdPreferido,HotelPreferido hotelPreferido);
        Task<HotelPreferido> DeleteHotelPreferidoByIdAsync(int idHotelPreferido);
        Task<IEnumerable<HotelPreferido>> GetAllHotelesPreferidosAsync();

    }
}
