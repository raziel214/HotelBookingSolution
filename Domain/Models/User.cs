using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Documento { get; set; }
        public string TipoDocumento { get; set; }
        public int IdRol { get; set; }

        // Relación con Rol
        public Rol Rol { get; set; }

    }
}
