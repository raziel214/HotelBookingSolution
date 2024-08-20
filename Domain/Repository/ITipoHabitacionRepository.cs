using Domain.Models.TiposHabitaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface ITipoHabitacionRepository
    {
        Task<IEnumerable<TiposHabitacion>> GetAllHabitacionAsync();
        Task<TiposHabitacion> GetHabitacionByIdAsync(int id);
        Task<TiposHabitacion> GetHabitacionByNombreAsync(string nombre);
        Task<TiposHabitacion> CreateHabitacionAsync(TiposHabitacion habitacion);
        Task UpdateHabitacionAsync(TiposHabitacion habitacion);
        Task<TiposHabitacion> DeleteHabitacionAsync(int id);
        Task<int> SaveChangesAsync();


    }
}
