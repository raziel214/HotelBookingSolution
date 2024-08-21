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
        Task<IEnumerable<TiposHabitacion>> GetAllHabitacionTipoAsync();
        Task<TiposHabitacion> GetHabitacionTipoByIdAsync(int id);
        Task<TiposHabitacion> GetHabitacionTipoByNombreAsync(string nombre);
        Task<TipoHabitacionRead> CreateHabitacionTipoAsync(TipoHabitacionCreate habitacion);
        Task UpdateHabitacionTipoAsync(TiposHabitacion habitacion);
        Task<TiposHabitacion> DeleteHabitacionTipoAsync(int id);
    }
}
