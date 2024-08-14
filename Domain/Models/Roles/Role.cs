using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Users;

namespace Domain.Models.Roles
{
    public class Role
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }

        // Relación inversa con Usuario
        public ICollection<User> Usuarios { get; set; }
    }
}
