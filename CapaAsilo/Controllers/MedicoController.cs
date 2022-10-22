using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad1;
using CapaNegocio;
using ClosedXML.Excel;

namespace CapaAsilo.Controllers
{
    public class MedicoController : Controller
    {

        // GET: Medico
        //******************* VISTAS ********************
        #region VISTAS
        public ActionResult SolicitudCitas ()
        {
            return View();
        }
         
        public ActionResult Pacientes()
        {
            return View();
        }

        public ActionResult FichaMedica()
        {
            return View();
        }
        public ActionResult Menu()
        {
            return View();
        }

        #endregion


        //***************** FICHA MEDICA ********************
        #region FICHA MEDICA
        public JsonResult VerFichaMedica(int IdCita)
        {
            Ficha objeto = new CN_Ficha().VerFicha(IdCita);
            return Json(new { resultado = objeto }, JsonRequestBehavior.AllowGet);

        }
        #endregion

        //***************** CITAS MEDICAS ********************
        #region CITAS MEDICAS
        [HttpGet]
        public ActionResult ListarCitas()
        {

            List<CitaMedica> olista = new List<CitaMedica>();

            olista = new CN_CitasMedicas().Listar();


            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GuardarCitaMedica(CitaMedica objeto) // guardar ficha medica
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdCita == 0)
            {
                resultado = new CN_CitasMedicas().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_CitasMedicas().Editar(objeto, out mensaje);
             

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EliminarCitaMedica(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new CN_CitasMedicas().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }
        #endregion


        //***************** PACIENTES ********************
         #region  PACIENTE


        [HttpGet]
        public ActionResult ListarPacientes()
        {

            List<Paciente> olista = new List<Paciente>();

            olista = new CN_Paciente().Listar();


            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GuardarPacientes(Paciente objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.COD_PACIENTE == 0)
            {
                resultado = new CN_Paciente().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Paciente().Editar(objeto, out mensaje);

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult EliminarPaciente(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new CN_Paciente().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region MENU
        [HttpGet]
        public JsonResult VistaMenu()
        {
            MenuMedico objeto = new CN_MenuMedico().verMenu();
            return Json(new {resultado = objeto}, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListaReportesCitas(string fechainicio, string fechafin)
        {
            List<ReporteCitas> olista = new List<ReporteCitas>();
            olista = new CN_Reportes().ReporteCitas(fechainicio, fechafin);
            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public FileResult ExportarCitas(string fechainicio, string fechafin)
        {
            List<ReporteCitas> oLista = new List<ReporteCitas>();
            oLista = new CN_Reportes().ReporteCitas(fechainicio, fechafin);

            DataTable dt = new DataTable();
            dt.Locale = new System.Globalization.CultureInfo("es-PE");
            dt.Columns.Add("FechaIngreso", typeof(string));
            dt.Columns.Add("Paciente", typeof(string));
            dt.Columns.Add("Medico", typeof(string));
            dt.Columns.Add("PrecioCita", typeof(decimal));
            dt.Columns.Add("Cantidad", typeof(int));

            foreach (ReporteCitas rp in oLista)
            {
                dt.Rows.Add(new object[]
                {
                    rp.FechaIngreso,
                    rp.Paciente,
                    rp.Medico,
                    rp.PrecioCita,
                    rp.Cantidad


                });
            }

            dt.TableName = "Datos";
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reporte de Citas " + DateTime.Now.ToString() + ".xlsx");
                }
            }

        }




        #endregion

    }
}