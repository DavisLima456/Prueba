using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad1
{
    public class Mensualidad
    {

        public int IdMensualidad { get; set; }
        public Paciente COD_PACIENTE { get; set; }
        public string Entrante { get; set; }
        public decimal Monto { get; set; }
        public Mes IdMes { get; set; }

    }
}
