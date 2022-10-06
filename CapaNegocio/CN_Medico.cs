using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad1;

namespace CapaNegocio
{
    public class CN_Medico
    {
        private Datos_Medico objDatosMedico = new Datos_Medico();
        public List<Medico> Listar()
        {
            return objDatosMedico.Listar();
        }

        public int Registrar(Medico obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if(string.IsNullOrEmpty(obj.Nombre)|| string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El Nombre del Medico No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Apellido) || string.IsNullOrWhiteSpace(obj.Apellido))
            {
                Mensaje = "El Apellido del Medico No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "El Correo del Medico No puede ser vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                

                return objDatosMedico.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }

          
        }

        public bool Editar(Medico obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El Nombre del Medico No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Apellido) || string.IsNullOrWhiteSpace(obj.Apellido))
            {
                Mensaje = "El Apellido del Medico No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "El Correo del Medico No puede ser vacio";
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
            return objDatosMedico.Eliminar(id,out Mensaje);
        }

    }
}
