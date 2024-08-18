using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Dtos.Habitaciones
{
    public class HabitacionCreate
    {
        public int IdHotel { get; set; }
        public int NumeroHabitacion { get; set; }
        public int IdTipoHabitacion { get; set; }
        public decimal CostoBase { get; set; }
        public int Estado { get; set; }
    }
}
