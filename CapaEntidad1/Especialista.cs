﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad1
{
    public class Especialista
    {
     

        public int IdEspecialista { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public bool Restablecer { get; set; }
        public bool Activo { get; set; }
        public Especialidad IdEspecialidad { get; set; }
        


    }
}
