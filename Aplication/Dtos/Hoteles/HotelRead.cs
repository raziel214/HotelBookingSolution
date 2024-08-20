using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Dtos.Hoteles
{
    public class HotelRead
    {
        public int IdHotel { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public string Ubicacion { get; set; }
        public short Estado { get; set; }
    }
}
