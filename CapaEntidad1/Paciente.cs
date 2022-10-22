using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad1
{
    public class Paciente
    {

        public int COD_PACIENTE { get; set; }
        public string Dpi { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Padecimientos { get; set; }
        public string Enfermedades { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public string Acompanante { get; set; }
        public string MotivoVista { get; set; }

        public string FechaRegistro { get; set; }

    }
}

