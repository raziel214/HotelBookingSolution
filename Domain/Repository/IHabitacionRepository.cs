using Domain.Models.Habitaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IHabitacionRepository
    {
        Task<IEnumerable<Habitacion>> GetAllHabitacionAsync();
        Task<Habitacion> GetByIdHabitacionAsync(int id);
        Task<Habitacion> GetHabitacionByCodeAsync(int code);
        Task<IEnumerable<Habitacion>> GetHabitacionByTypeAsync(int type);
        Task<IEnumerable<Habitacion>> GetHabitacionByPriceAsync(int price);
        Task<IEnumerable<Habitacion>> GetHabitacionByStatusAsync(int status);
        Task<IEnumerable<Habitacion>> GetHabitacionByHotelAsync(int hotelId);
        Task<Habitacion> CreateHabitacionAsync(Habitacion habitacion);
        Task UpdateHabitacionAsync(int id,Habitacion habitacion);
        Task<Habitacion> DeleteHabitacionByIdAsync(int id);
        Task<int> SaveChangesAsync();
    }
}
