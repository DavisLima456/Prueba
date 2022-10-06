using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad1;

namespace CapaNegocio
{
    public class CN_Usuario
    {

        private Datos_Usuario objDatosMedico = new Datos_Usuario();
        public List<Usuario> Listar()
        {
            return objDatosMedico.Listar();
        }

        public int Registrar(Usuario obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.NOMBRE) || string.IsNullOrWhiteSpace(obj.NOMBRE))
            {
                Mensaje = "El Nombre del usuario No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.APELLIDO) || string.IsNullOrWhiteSpace(obj.APELLIDO))
            {
                Mensaje = "El Apellido del usuario No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.CORREO) || string.IsNullOrWhiteSpace(obj.CORREO))
            {
                Mensaje = "El Correo del usuario No puede ser vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {

                string clave = "test123";
                obj.CLAVE = CN_Recursos.ConvertirSha256(clave);

                return objDatosMedico.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }


        }

        //editar 
        public bool Editar(Usuario obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.NOMBRE) || string.IsNullOrWhiteSpace(obj.NOMBRE))
            {
                Mensaje = "El Nombre del usuario No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.APELLIDO) || string.IsNullOrWhiteSpace(obj.APELLIDO))
            {
                Mensaje = "El Apellido del usuario No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.CORREO) || string.IsNullOrWhiteSpace(obj.CORREO))
            {
                Mensaje = "El Correo del usuario No puede ser vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objDatosMedico.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objDatosMedico.Eliminar(id, out Mensaje);
        }




    }
}
