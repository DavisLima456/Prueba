using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad1
{
    public class ReporteCitas
    {
        public string FechaIngreso { get; set; }
        public string Paciente { get; set; }
        public string Medico { get; set; }
        public decimal PrecioCita { get; set; }
        public int Cantidad { get; set; }

    }
}
