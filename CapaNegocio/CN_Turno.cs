using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad1;
namespace CapaNegocio
{
    public class CN_Turno
    {
        private Datos_Turno objturno = new Datos_Turno();

        public List<Turno> Listar()
        {
            return objturno.Listar();
        }

        public int Registrar(Turno obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.Horario) || string.IsNullOrWhiteSpace(obj.Horario))
            {
                Mensaje = "El Horario No puede ser vacio";
            }
            

            if (string.IsNullOrEmpty(Mensaje))
            {


                return objturno.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }


        }
        public bool Editar(Turno obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.Horario) || string.IsNullOrWhiteSpace(obj.Horario))
            {
                Mensaje = "El horario No puede ser vacio";
            }
           


            if (string.IsNullOrEmpty(Mensaje))
            {
                return objturno.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objturno.Eliminar(id, out Mensaje);
        }



    }
}
