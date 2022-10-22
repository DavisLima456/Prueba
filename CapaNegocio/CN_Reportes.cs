using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad1;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Reportes
    {
        private Datos_Reportes objCapaDato = new Datos_Reportes();

        public List<Reporte1> Reporte1(int IdTipo)
        {
            return objCapaDato.ListarReporte1(IdTipo);
        }
        public List<Reporte2> ListarReporte2()
        {
            return objCapaDato.ListarReporte2();
        }

        public List<Reporte1> Ventas()
        {
            return objCapaDato.Ventas();
        }

        public List<ReporteCitas> ReporteCitas(string fechainicio, string fechafin)
        {
            return objCapaDato.ReporteCitas(fechainicio, fechafin);
        }

        public List<Reporte3> ListarReporte3(string fechainicio, string fechafin)
        {
            return objCapaDato.ListarReporte3(fechainicio, fechafin);
        }
        public List<Reporte4> ListarReporte4()
        {
            return objCapaDato.ListarReporte4();
        }
        public List<Reporte5> ListarReporte5()
        {
            return objCapaDato.ListarReporte5();
        }

        public List<Reporte6> ListarReporte6()
        {
            return objCapaDato.ListarReporte6();
        }
        public List<Reporte7> ListarReporte7()
        {
            return objCapaDato.ListarReporte7();
        }
    }
}
