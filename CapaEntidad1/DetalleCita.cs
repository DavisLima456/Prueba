using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad1
{
    public class DetalleCita
    {

        public int IdDetalleCita { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public TipoDetalleCitaMedica oTipoDetalleCita { get; set; }


    }
}
