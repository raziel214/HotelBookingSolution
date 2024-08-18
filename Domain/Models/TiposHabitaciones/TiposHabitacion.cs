using Domain.Models.Habitaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.TiposHabitaciones
{
    public class TiposHabitacion
    {
        public int IdTipoHabitacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        // Relación con Habitacion
        public ICollection<Habitacion> Habitaciones { get; set; }
    }
}
