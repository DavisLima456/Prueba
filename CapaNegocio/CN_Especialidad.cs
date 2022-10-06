using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad1;

namespace CapaNegocio
{
    public class CN_Especialidad
    {
        private Datos_Especialidad objDatosEspecialidad = new Datos_Especialidad();
        public List<Especialidad> Listar()
        {
            return objDatosEspecialidad.Listar();
        }
        public int Registrar(Especialidad obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El Nombre de la Especialidad No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La Descripcion de la Especialidad No puede ser vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {


                return objDatosEspecialidad.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }


        }
        public bool Editar(Especialidad obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El Nombre de la Especialidad No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La Descripcion de la especialidad No puede ser vacio";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {
                return objDatosEspecialidad.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objDatosEspecialidad.Eliminar(id, out Mensaje);
        }



    }
}
