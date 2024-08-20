using Domain.Models.HotelesPreferidos;
using Domain.Models.Reservas;
using Domain.Models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Users
{
    public class User
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Documento { get; set; }
        public string TipoDocumento { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdRol { get; set; }
        public string Genero { get; set; }
        public string Telefono { get; set; }

        // Relación con Rol
        public Role Rol { get; set; }
        // Relación con Reserva
        public ICollection<Reserva> Reservas { get; set; }

        // Relación con HotelPreferido
        public ICollection<HotelPreferido> HotelesPreferidos { get; set; }
    }
}
