using CapaDatos;
using CapaEntidad1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Estados
    {
        private Datos_Estados objEstado = new Datos_Estados();

        public List<Estado> Listar()
        {
            return objEstado.Listar();
        }

        public int Registrar(Estado obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La descriocion del estado No puede ser vacio";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {


                return objEstado.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }


        }
        public bool Editar(Estado obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La descriocion del estado No puede ser vacio";
            }



            if (string.IsNullOrEmpty(Mensaje))
            {
                return objEstado.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objEstado.Eliminar(id, out Mensaje);
        }


    }
}
