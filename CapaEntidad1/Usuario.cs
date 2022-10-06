using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad1
{
    public class Usuario
    {

        public int ID_USUARIO { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string CORREO { get; set; }
        public string CLAVE { get; set; }
        public int ROL { get; set; }
        public bool RESTABLECER { get; set; }
        public bool ACTIVO { get; set; }

        public string FechaRegistro { get; set; }

    }
}
