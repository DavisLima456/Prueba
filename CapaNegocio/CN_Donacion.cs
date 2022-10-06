using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad1;

namespace CapaNegocio
{
    public class CN_Donacion
    {
        private Datos_Donacion objDonacion = new Datos_Donacion();

        public List<Donacion> Listar()
        {
            return objDonacion.Listar();
        }

        public int Registrar(Donacion obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.Donante) || string.IsNullOrWhiteSpace(obj.Donante))
            {
                Mensaje = "El Nombre del Donante No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.oFundacion.NombreFundacion) || string.IsNullOrWhiteSpace(obj.oFundacion.NombreFundacion))
            {
                Mensaje = "El Nombre de la fundacion No puede ser vacio";
            }
            else if (obj.MontoDonado == 0)
            {
                Mensaje = "Falta la Cantidad a Donar ";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {


                return objDonacion.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }


        }
        public bool Editar(Donacion obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.Donante) || string.IsNullOrWhiteSpace(obj.Donante))
            {
                Mensaje = "El Nombre del Donante No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.oFundacion.NombreFundacion) || string.IsNullOrWhiteSpace(obj.oFundacion.NombreFundacion))
            {
                Mensaje = "El Nombre de la Fundacion No puede ser vacio";
            }
            else if (obj.MontoDonado == 0)
            {
                Mensaje = "Falta la Cantidad a Donar ";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objDonacion.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objDonacion.Eliminar(id, out Mensaje);
        }


    }
}
