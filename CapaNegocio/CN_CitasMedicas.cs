using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad1;

namespace CapaNegocio
{
    // Esta Clase los que nos permite establecer las reglas del negocio.

    public class CN_CitasMedicas
    {
        private Datos_CitaMedica objCitaMedica = new Datos_CitaMedica();

        //metodo para listar, 
        public List<CitaMedica> Listar()
        {
            return objCitaMedica.Listar();
        }

        //para guardar una cita. ficha
        public int Registrar(CitaMedica obj, out string Mensaje)
        {
            //En esta parte verificamos que los campos del formulario no esten vacios.
            // de estar vacios retonara un mesaje  
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.oMedico.Nombre) || string.IsNullOrWhiteSpace(obj.oMedico.Nombre))
            {
                Mensaje = "El Nombre del Medico No puede ser vacio";

            }else if(string.IsNullOrEmpty(obj.oPaciente.Nombre) || string.IsNullOrWhiteSpace(obj.oPaciente.Nombre))
                {
                Mensaje = "El Nombre del paciente No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Cintomas) || string.IsNullOrWhiteSpace(obj.Cintomas))
                {
                Mensaje = "El campo no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.oEspecialista.Nombre) || string.IsNullOrWhiteSpace(obj.oEspecialista.Nombre))
                {
                Mensaje = "El Nombre del especialista No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.oEnfermero.Nombre) || string.IsNullOrWhiteSpace(obj.oEnfermero.Nombre))
                {
                Mensaje = "El Nombre del Enfermero No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.PrecioCita.ToString()) || string.IsNullOrWhiteSpace(obj.PrecioCita.ToString()))
                {
                Mensaje = "El campo No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.oTurno.Horario) || string.IsNullOrWhiteSpace(obj.oTurno.Horario))
                {
                Mensaje = "El campo No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.oEstado.Descripcion) || string.IsNullOrWhiteSpace(obj.oEstado.Descripcion))
                {
                Mensaje = "El campo No puede ser vacio";
            }
            if (string.IsNullOrEmpty(Mensaje))
            {


                return objCitaMedica.Registrar(obj, out Mensaje);



            }
            else
            {


                return 0;
            }

        }

        //para editar una cita.
        public bool Editar(CitaMedica obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.oMedico.Nombre) || string.IsNullOrWhiteSpace(obj.oMedico.Nombre))
            {
                Mensaje = "El Nombre del Medico No puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.oPaciente.Nombre) || string.IsNullOrWhiteSpace(obj.oPaciente.Nombre))
            {
                Mensaje = "El Nombre del paciente No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Cintomas) || string.IsNullOrWhiteSpace(obj.Cintomas))
            {
                Mensaje = "El campo no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.oEspecialista.Nombre) || string.IsNullOrWhiteSpace(obj.oEspecialista.Nombre))
            {
                Mensaje = "El Nombre del especialista No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.oEnfermero.Nombre) || string.IsNullOrWhiteSpace(obj.oEnfermero.Nombre))
            {
                Mensaje = "El Nombre del Enfermero No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.PrecioCita.ToString()) || string.IsNullOrWhiteSpace(obj.PrecioCita.ToString()))
            {
                Mensaje = "El campo No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.oTurno.Horario) || string.IsNullOrWhiteSpace(obj.oTurno.Horario))
            {
                Mensaje = "El campo No puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.oEstado.Descripcion) || string.IsNullOrWhiteSpace(obj.oEstado.Descripcion))
            {
                Mensaje = "El campo No puede ser vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCitaMedica.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        // para eliminar una cita
        
        public bool Eliminar(int id, out string Mensaje)
        {
            return objCitaMedica.Eliminar(id, out Mensaje);
        }


        //para asignar los resultados
        public bool DarResultado(AsignarResultados obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.IdCita == 0)
            {
                Mensaje = "Falta el numero de la cita ";
            }

            else if (string.IsNullOrEmpty(obj.Resultados) || string.IsNullOrWhiteSpace(obj.Resultados))
            {
                Mensaje = "Falta los los resultado";
            }



            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCitaMedica.DarResultados(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }



    }
}
