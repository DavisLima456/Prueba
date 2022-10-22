using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad1
{
    public class CitaMedica
    {

     
        public int IdCita { get; set; }
        
        public Medico oMedico { get; set; }
        public Paciente oPaciente { get; set; }
        public string Cintomas { get; set; }
        public Especialista oEspecialista { get; set; }
        public Enfermero oEnfermero { get; set; }
        public decimal PrecioCita { get; set; }
        public Turno oTurno { get; set; }
        public Estado oEstado { get; set; }
        public string FechaRegistro { get; set; }
        public string Resultado { get; set; }
        public string Idtransaccion { get; set; }


    }
}
