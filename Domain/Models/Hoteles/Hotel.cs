using Domain.Models.Habitaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Hoteles
{
    public class Hotel
    {
        [Key]
        public int IdHotel { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public string Ubicacion { get; set; }
        public short Estado { get; set; }

        // Relación con Habitacion
        public ICollection<Habitacion> Habitaciones { get; set; }
    }
}
