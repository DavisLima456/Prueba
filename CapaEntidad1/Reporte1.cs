using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad1
{
    public class Reporte1
    {
        public int IdTipo { get; set; }
        public int No_Cita { get; set; }
        public int Cod_Paciente { get; set; }
        public string Paciente { get; set; }
        public decimal CostoCita { get; set; }
        public string Exa_Med { get; set; }
        public decimal Costo_ExaMed { get; set; }
    }
}
