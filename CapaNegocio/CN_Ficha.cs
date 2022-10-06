using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad1;

namespace CapaNegocio
{
    public class CN_Ficha
    {
        private Datos_Ficha objCapaDato = new Datos_Ficha();
        public Ficha VerFicha(int IdCita)
        {

            return objCapaDato.VerFicha(IdCita);
        }

    }
}
