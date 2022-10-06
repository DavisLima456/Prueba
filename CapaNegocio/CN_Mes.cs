using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad1;
using CapaDatos;


namespace CapaNegocio
{
    public class CN_Mes
    {
        private Datos_Meses objmes = new Datos_Meses();

        public List<Mes> Listar()
        {
            return objmes.Listar();
        }
        public int Registrar(Mes obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.NombreMes) || string.IsNullOrWhiteSpace(obj.NombreMes))
            {
                Mensaje = "El Nombre del Mes No puede ser vacio";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {


                return objmes.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }


        }
        public bool Editar(Mes obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.NombreMes) || string.IsNullOrWhiteSpace(obj.NombreMes))
            {
                Mensaje = "El Nombre del Mes No puede ser vacio";
            }



            if (string.IsNullOrEmpty(Mensaje))
            {
                return objmes.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objmes.Eliminar(id, out Mensaje);
        }

    }
}
