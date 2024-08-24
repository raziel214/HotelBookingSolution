using Domain.Models.Hoteles;
using Domain.Models.Reservas;
using Domain.Models.TiposHabitaciones;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Habitaciones
{
    public class Habitacion
    {
        [Key]
        public int IdHabitacion { get; set; }
        public int IdHotel { get; set; }
        public int NumeroHabitacion { get; set; }
        public int IdTipoHabitacion { get; set; }
        public decimal CostoBase { get; set; }
        public int Estado { get; set; }
        public int CantidadPersonas { get; set; }


        // Relación con Hotel
        public Hotel Hotel { get; set; }

        // Relación con Hotel
        public TiposHabitacion TiposHabitacion { get; set; }

        public ICollection<Reserva>  Reserva { get; set; }


    }
}
