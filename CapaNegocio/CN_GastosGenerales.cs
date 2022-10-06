using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad1;

namespace CapaNegocio
{
    public class CN_GastosGenerales
    {

        private Datos_GastosGenerales objCapaDato = new Datos_GastosGenerales();

        public List<GastosGenerales> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(GastosGenerales obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.NombreGasto) || string.IsNullOrWhiteSpace(obj.NombreGasto))
            {
                Mensaje = "El nombre del gasto no puede ser vacio";
            }
            else if (obj.MontoGasto == 0)
            {
                Mensaje = "El monto no peuede estar vacio";
            }

            else if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "Los  descripcion no puede estar vacio no peuede estar vascio";
            }



            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Registrar(obj, out Mensaje);

            }
            else
            {


                return 0;
            }

        }




        public bool Editar(GastosGenerales obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreGasto) || string.IsNullOrWhiteSpace(obj.NombreGasto))
            {
                Mensaje = "El nombre del gasto no puede ser vacio";
            }
            else if (obj.MontoGasto == 0)
            {
                Mensaje = "El monto no peuede estar vacio";
            }

            else if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "Los  descripcion no puede estar vacio no peuede estar vascio";
            }



            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }


        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }
    }
}
