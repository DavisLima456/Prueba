using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad1
{
    public class VistaCita
    {
        public int IdCita { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; }
    }
}
