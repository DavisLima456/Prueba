using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad1;


namespace CapaNegocio
{
    public class CN_Paciente
    {
        private Datos_Paciente objDatosPaciente = new Datos_Paciente();

        //para listar 
        public List<Paciente> Listar()
        {
            return objDatosPaciente.Listar();
        }

        //para guardar pacientes
        public int Registrar(Paciente obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El Nombre del Paciente No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Apellido) || string.IsNullOrWhiteSpace(obj.Apellido))
            {
                Mensaje = "El Apellido del Paciente No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "El Correo del Familiar del Paciente No puede ser vacio";
            }

            else if (string.IsNullOrEmpty(obj.Padecimientos) || string.IsNullOrWhiteSpace(obj.Padecimientos))
            {
                Mensaje = "El campo de padecimientos no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(obj.Enfermedades) || string.IsNullOrWhiteSpace(obj.Enfermedades))
            {
                Mensaje = "El campo de enfermedades no puede estar vacio";
            }

            else if (string.IsNullOrEmpty(obj.Dpi) || string.IsNullOrWhiteSpace(obj.Dpi))
            {
                Mensaje = "El campo del Dpi no puede estar vacio";
            }
          
            else if (obj.Edad == 0)
            {
                Mensaje = "Debe ingresar la edad del paciente";
            }
            else if (obj.Edad > 100)
            {
                Mensaje = "La Edad esta Fuera del Rango";
            }
            else if (string.IsNullOrEmpty(obj.Genero) || string.IsNullOrWhiteSpace(obj.Genero))
            {
                Mensaje = "El genero no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(obj.Acompanante) || string.IsNullOrWhiteSpace(obj.Acompanante))
            {
                Mensaje = "El campo del acompañante no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(obj.MotivoVista) || string.IsNullOrWhiteSpace(obj.MotivoVista))
            {
                Mensaje = "El Motivo de visita no puede estar vacio";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {


                return objDatosPaciente.Registrar(obj, out Mensaje);



            }
            else
            {


                return 0;
            }




        }

        //para editar un paciente.
        public bool Editar(Paciente obj, out string Mensaje)
        {
            Mensaje = String.Empty;





            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El Nombre del paciente No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Apellido) || string.IsNullOrWhiteSpace(obj.Apellido))
            {
                Mensaje = "El Apellido del paciente No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "El Correo del Familiar del Paciente No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Dpi) || string.IsNullOrWhiteSpace(obj.Dpi))
            {
                Mensaje = "El campo del Dpi no puede estar vacio";
            }

            else if (string.IsNullOrEmpty(obj.Padecimientos) || string.IsNullOrWhiteSpace(obj.Padecimientos))
            {
                Mensaje = "El campo no puede ser vacio";
            }
            else if (obj.Edad == 0)
            {
               
                    Mensaje = "Debe ingresar la edad del paciente";
            }
            else if (obj.Edad > 100)
            {
                Mensaje = "La Edad esta Fuera del Rango";
            }
            else if (string.IsNullOrEmpty(obj.Genero) || string.IsNullOrWhiteSpace(obj.Genero))
            {
                Mensaje = "El genero no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(obj.Acompanante) || string.IsNullOrWhiteSpace(obj.Acompanante))
            {
                Mensaje = "El campo del acompañante no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(obj.MotivoVista) || string.IsNullOrWhiteSpace(obj.MotivoVista))
            {
                Mensaje = "El Motivo de visita no puede estar vacio";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {
                return objDatosPaciente.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        // para eliminar un paciente
        public bool Eliminar(int id, out string Mensaje)
        {
            return objDatosPaciente.Eliminar(id, out Mensaje);
        }



    }
}
