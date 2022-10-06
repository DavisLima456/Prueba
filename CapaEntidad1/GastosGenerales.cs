using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad1
{
    public class GastosGenerales
    {
        public int IdGastosGenerales { get; set; }
        public string NombreGasto { get; set; }
        public string Descripcion { get; set; }
        public decimal MontoGasto { get; set; }
        public string Fecha { get; set; }
    }
}
