using Domain.Models.Habitaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Dtos.HabitacionesTipos
{
    public class TipoHabitacionCreate
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }        
    }
}
