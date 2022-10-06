using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad1;

namespace CapaNegocio
{
    public class CN_Fundacion
    {
        private Datos_Fundacion objfundacion = new Datos_Fundacion();

        public List<Fundacion> Listar()
        {
            return objfundacion.Listar();
        }

        public int Registrar(Fundacion obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.NombreFundacion) || string.IsNullOrWhiteSpace(obj.NombreFundacion))
            {
                Mensaje = "El Nombre de la fundacion No puede ser vacio";
            }
           else if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "El Nombre de la fundacion No puede ser vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {


                return objfundacion.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }


        }
        public bool Editar(Fundacion obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.NombreFundacion) || string.IsNullOrWhiteSpace(obj.NombreFundacion))
            {
                Mensaje = "El Nombre del Mes No puede ser vacio";
            }
           else if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "El Nombre del Mes No puede ser vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objfundacion.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objfundacion.Eliminar(id, out Mensaje);
        }

    }
}
