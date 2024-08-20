using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Dtos.Usuarios
{
    public class UserLogin
    {
        public string UserEmail { get; set; }  // O Email si prefieres usar correo electrónico
        public string Password { get; set; }
    }
}
