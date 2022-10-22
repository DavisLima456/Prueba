using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad1;


namespace CapaNegocio
{
    public class CN_CostosMedico
    {

        private Datos_CostosMedico objCapaDato = new Datos_CostosMedico();
        
        //Metodo para listar los examenes
        public List<CostoMedico> ListaCostoMedicos(int IdCita)
        {
            return objCapaDato.Listar(IdCita);


        }

        //Metodo para listar los medicamentos
        public List<CostoMedico> ListaMedicamentos(int IdCita)
        {
            return objCapaDato.Listar_Medicamento(IdCita);


        }



        //metodo para asignar un examen
        public int Registrar(CostoMedico obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (obj.oCitaMedica.IdCita == 0)
            {
                Mensaje = "No puede estar vacion ";
            }
            else if (obj.oIdDetalleCita.IdDetalleCita == 0)
            {
                Mensaje = "Debe selecionar ";
            }
            else if (obj.Cantidad == 0)
            {
                Mensaje = "No puede estar vacia la candidad ";
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

        //metodo para eliminar un examen
        public bool Eliminar(int id, int i, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, i, out Mensaje);
        }

        public VerPaciente List_Paciente(int IdCita)
        {

            return objCapaDato.List_Paciente(IdCita);
        }

        //metodo pra ver el datalle de la cita
        public List<VistaCita> DetalleCita(int IdCita)
        {
            return objCapaDato.DetalleCita(IdCita);


        }

        public TotalCita Totalcita(int IdCita)
        {

            return objCapaDato.Totalcita(IdCita);
        }
        public VerCitas VerCitas(int IdCita)
        {

            return objCapaDato.VerCitas(IdCita);
        }


    }
}
