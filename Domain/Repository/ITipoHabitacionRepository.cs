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
        Task<IEnumerable<TiposHabitacion>> GetAllHabitacionTipoAsync();
        Task<TiposHabitacion> GetHabitacionTipoByIdAsync(int id);
        Task<TiposHabitacion> GetHabitacionTipoByNombreAsync(string nombre);
        Task<TiposHabitacion> CreateTipoHabitacionAsync(TiposHabitacion habitacion);
        Task UpdateHabitacionTipoAsync(TiposHabitacion habitacion);
        Task<TiposHabitacion> DeleteHabitacionTipoAsync(int id);
        Task<int> SaveChangesAsync();


    }
}
