using Aplication.Dtos.Hoteles;
using Domain.Models.Hoteles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Service.Hoteles
{
    public interface IHotelService
    {
        Task<Hotel> GetHotelByIdAsync(int id);
        Task<Hotel> GetHotelByNameAsync(string name);
        Task<Hotel> GetHotelByCodeAsync(string code);
        Task<HotelRead> CreateHotelAsync(HotelCreate hotel);
        Task UpdateHotelAsync(int id, Hotel hotel);
        Task<Hotel> DeleteHotelByIdAsync(int id);
        Task<IEnumerable<Hotel>> GetAllHotelsAsync();
    }
}
