using Domain.Models.Hoteles;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.HotelesPreferidos
{
    public class HotelPreferido
    {
        [Key]
        public int IdPreferido { get; set; }
        public int IdUsuario { get; set; }
        public int IdHotel { get; set; }

        // Relación con Usuario
        public User Usuario { get; set; }

        // Relación con Hotel
        public Hotel Hotel { get; set; }
    }
}
