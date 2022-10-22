using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad1
{
    public class VerPaciente
    {
        public string Fecha { get; set; }
        public int IdCita { get; set; }
        public string Nombre { get; set; }
        public string Medico { get; set; }
        public string Padecimientos { get; set; }
        public string MotivoVisita { get; set; }
        public string Descripcion { get; set; }
    }
}
