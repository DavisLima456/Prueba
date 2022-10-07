using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad1;

namespace CapaNegocio
{
    public class CN_PagoMensualidad
    {
        private Datos_PagoMensualidad objMensualidad = new Datos_PagoMensualidad();
        public List<Mensualidad> Listar()
        {
            return objMensualidad.Listar();
        }

        public int Registrar(Mensualidad obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.oPaciente.Nombre) || string.IsNullOrWhiteSpace(obj.oPaciente.Nombre))
            {
                Mensaje = "El Nombre del Paciente No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Entrante) || string.IsNullOrWhiteSpace(obj.Entrante))
            {
                Mensaje = "El campo No puede ser vacio";
            }
            else if (obj.Monto == 0)
            {
                Mensaje = "Falta la cantidad";
            }
            else if (string.IsNullOrEmpty(obj.oMes.NombreMes) || string.IsNullOrWhiteSpace(obj.oMes.NombreMes))
            {
                Mensaje = "El Campo Mes No puede ser vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {


                return objMensualidad.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }


        }
        public bool Editar(Mensualidad obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.oPaciente.Nombre) || string.IsNullOrWhiteSpace(obj.oPaciente.Nombre))
            {
                Mensaje = "El Nombre del Paciente No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Entrante) || string.IsNullOrWhiteSpace(obj.Entrante))
            {
                Mensaje = "El campo No puede ser vacio";
            }
            else if (obj.Monto == 0)
            {
                Mensaje = "Falta la cantidad";
            }
            else if (string.IsNullOrEmpty(obj.oMes.NombreMes) || string.IsNullOrWhiteSpace(obj.oMes.NombreMes))
            {
                Mensaje = "El Campo Mes No puede ser vacio";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {
                return objMensualidad.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objMensualidad.Eliminar(id, out Mensaje);
        }
    }
}
