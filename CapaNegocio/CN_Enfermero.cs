using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad1;


namespace CapaNegocio
{
    public class CN_Enfermero
    {
        private Datos_Enfermero objDatosEnfermero = new Datos_Enfermero();
        public List<Enfermero> Listar()
        {
            return objDatosEnfermero.Listar();
        }

        public int Registrar(Enfermero obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El Nombre del enfermero No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Apellido) || string.IsNullOrWhiteSpace(obj.Apellido))
            {
                Mensaje = "El Apellido del enfermero No puede ser vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {


                return objDatosEnfermero.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }


        }
        public bool Editar(Enfermero obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El Nombre del enfermero No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Apellido) || string.IsNullOrWhiteSpace(obj.Apellido))
            {
                Mensaje = "El Apellido del enfermero No puede ser vacio";
            }
           

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objDatosEnfermero.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objDatosEnfermero.Eliminar(id, out Mensaje);
        }


    }

}
