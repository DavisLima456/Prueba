using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad1;

namespace CapaNegocio
{
    public class CN_MenuMedico
    {
        private DatosMenuMedico objDatosMedico = new DatosMenuMedico();
        public MenuMedico verMenu()
        {
            return objDatosMedico.verMenu();
        }
    }
}
