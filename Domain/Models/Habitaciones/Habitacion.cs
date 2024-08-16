using Domain.Models.Hoteles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Habitaciones
{
    public class Habitacion
    {
        public int IdHabitacion { get; set; }
        public int IdHotel { get; set; }
        public int NumeroHabitacion { get; set; }
        public int IdTipoHabitacion { get; set; }
        public decimal CostoBase { get; set; }
        public int Estado { get; set; }

        // Relación con Hotel
        public Hotel Hotel { get; set; }

      
    }
}
