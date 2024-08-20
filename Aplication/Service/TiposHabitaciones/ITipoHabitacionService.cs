using Aplication.Dtos.HabitacionesTipos;
using Domain.Models.TiposHabitaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Service.TiposHabitaciones
{
    public interface ITipoHabitacionService
    {
        Task<IEnumerable<TiposHabitacion>> GetAllHabitacionAsync();
        Task<TiposHabitacion> GetHabitacionByIdAsync(int id);
        Task<TiposHabitacion> GetHabitacionByNombreAsync(string nombre);
        Task<TipoHabitacionRead> CreateHabitacionAsync(TipoHabitacionCreate habitacion);
        Task UpdateHabitacionAsync(TiposHabitacion habitacion);
        Task<TiposHabitacion> DeleteHabitacionAsync(int id);
    }
}
