using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Role
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }

        // Relación inversa con Usuario
        public ICollection<User> Usuarios { get; set; }
    }
}
