using Aplication.Dtos.Habitaciones;
using Domain.Models.Habitaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Service.Habitaciones
{
    public interface IHabitacionService
    {
        Task<IEnumerable<Habitacion>> GetAllHabitacionAsync();
        Task<Habitacion> GetByIdHabitacionAsync(int id);
        Task<Habitacion> GetHabitacionByCodeAsync(string code);
        Task<Habitacion> GetHabitacionByTypeAsync(string type);
        Task<Habitacion> GetHabitacionByPriceAsync(int price);
        Task<Habitacion> GetHabitacionByStatusAsync(string status);
        Task<Habitacion> GetHabitacionByHotelAsync(int hotel);
        Task<HabitacionRead> CreateHabitacionAsync(HabitacionCreate habitacion);
        Task  UpdateHabitacionAsync(int id, Habitacion habitacion);
        Task<Habitacion> DeleteHabitacionAsync(int id);


    }
}
