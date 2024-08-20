using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Usuarios
{
    public class UserRead
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
    }
}
