using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocio;
using CapaEntidad1;
using System.Data;
using ClosedXML.Excel;
using System.IO;

namespace CapaAsilo.Controllers
{
    public class ReportesController : Controller
    {
        // GET: Reportes
        public ActionResult Reporte1()
        {
            return View();
        }
        public ActionResult Reporte2()
        {
            return View();
        }
        public ActionResult Reporte3()
        {
            return View();
        }
        public ActionResult Reporte4()
        {
            return View();
        }
        public ActionResult Reporte5()
        {
            return View();
        }
        public ActionResult Reporte6()
        {
            return View();
        }
        public ActionResult Reporte7()
        {
            return View();
        }

        [HttpGet]
        public JsonResult VerReporte1(int IdTipo)
        {
            List<Reporte1> olista = new List<Reporte1>();
            olista = new CN_Reportes().Reporte1(IdTipo);
            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public FileResult ExportarVenta() 
        {
            List<Reporte1> oLista = new List<Reporte1>();
            oLista = new CN_Reportes().Ventas();

            DataTable dt = new DataTable();
            dt.Locale = new System.Globalization.CultureInfo("es-PE");
            dt.Columns.Add("No_Cita", typeof(int));
            dt.Columns.Add("Paciente", typeof(string));
            dt.Columns.Add("CostoCita", typeof(decimal));
            dt.Columns.Add("Exa_Med", typeof(string));
            dt.Columns.Add("Costo_ExaMed", typeof(decimal));       

            foreach (Reporte1 rp in oLista)
            {
                dt.Rows.Add(new object[]
                {
                    rp.No_Cita,
                    rp.Paciente,
                    rp.CostoCita,
                    rp.Exa_Med,
                    rp.Costo_ExaMed
                    

                });
            }

            dt.TableName = "Datos";
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reporte 1 " + DateTime.Now.ToString() + ".xlsx");
                }
            }

        }
        public JsonResult VerReporte2()
        {
            List<Reporte2> olista = new List<Reporte2>();
            olista = new CN_Reportes().ListarReporte2();
            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public FileResult ExportarReporte2()
        {
            List<Reporte2> oLista = new List<Reporte2>();
            oLista = new CN_Reportes().ListarReporte2();

            DataTable dt = new DataTable();
            dt.Locale = new System.Globalization.CultureInfo("es-PE");
            dt.Columns.Add("IdCita", typeof(int));
            dt.Columns.Add("Paciente", typeof(string));
            dt.Columns.Add("Cintomas", typeof(string));
            dt.Columns.Add("Medicamentos", typeof(string));
            dt.Columns.Add("Examenes", typeof(string));

            foreach (Reporte2 rp in oLista)
            {
                dt.Rows.Add(new object[]
                {
                    rp.IdCita,
                    rp.Paciente,
                    rp.Cintomas,
                    rp.Medicamentos,
                    rp.Examenes


                });
            }

            dt.TableName = "Datos";
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reporte 2 " + DateTime.Now.ToString() + ".xlsx");
                }
            }
        }



            public JsonResult VerReporte3(string fechainicio, string fechafin)
        {
            List<Reporte3> olista = new List<Reporte3>();
            olista = new CN_Reportes().ListarReporte3(fechainicio, fechafin);
            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }
        public JsonResult VerReporte4()
        {
            List<Reporte4> olista = new List<Reporte4>();
            olista = new CN_Reportes().ListarReporte4();
            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public FileResult ExportarReporte4()
        {
            List<Reporte4> oLista = new List<Reporte4>();
            oLista = new CN_Reportes().ListarReporte4();

            DataTable dt = new DataTable();
            dt.Locale = new System.Globalization.CultureInfo("es-PE");
            dt.Columns.Add("PACIENTE", typeof(string));
            dt.Columns.Add("Monto", typeof(decimal));
            dt.Columns.Add("Fecha", typeof(string));
            dt.Columns.Add("Descripcion", typeof(string));
            dt.Columns.Add("NombreMes", typeof(string));

            foreach (Reporte4 rp in oLista)
            {
                dt.Rows.Add(new object[]
                {
                    rp.PACIENTE,
                    rp.Monto,
                    rp.Fecha,
                    rp.Descripcion,
                    rp.NombreMes


                });
            }

            dt.TableName = "Datos";
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reporte 4 " + DateTime.Now.ToString() + ".xlsx");
                }
            }
        }


        public JsonResult VerReporte5()
        {
            List<Reporte5> olista = new List<Reporte5>();
            olista = new CN_Reportes().ListarReporte5();
            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public FileResult ExportarReporte5()
        {
            List<Reporte5> oLista = new List<Reporte5>();
            oLista = new CN_Reportes().ListarReporte5();

            DataTable dt = new DataTable();
            dt.Locale = new System.Globalization.CultureInfo("es-PE");
            dt.Columns.Add("Persona", typeof(string));
            dt.Columns.Add("Cantidad", typeof(int));
            dt.Columns.Add("Descripcion", typeof(string));
            dt.Columns.Add("Fecha", typeof(string));
           
            

            foreach (Reporte5 rp in oLista)
            {
                dt.Rows.Add(new object[]
                {
                    rp.Persona,
                    rp.Cantidad,
                    rp.Descripcion,
                    rp.Fecha,
                  
                    


                });
            }

            dt.TableName = "Datos";
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reporte 5 " + DateTime.Now.ToString() + ".xlsx");
                }
            }
        }

        public JsonResult VerReporte6()
        {
            List<Reporte6> olista = new List<Reporte6>();
            olista = new CN_Reportes().ListarReporte6();
            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public FileResult ExportarReporte6()
        {
            List<Reporte6> oLista = new List<Reporte6>();
            oLista = new CN_Reportes().ListarReporte6();

            DataTable dt = new DataTable();
            dt.Locale = new System.Globalization.CultureInfo("es-PE");
            dt.Columns.Add("IdCita", typeof(int));
            dt.Columns.Add("Paciente", typeof(string));
            dt.Columns.Add("Examen", typeof(string));
            dt.Columns.Add("Cantidad", typeof(int));



            foreach (Reporte6 rp in oLista)
            {
                dt.Rows.Add(new object[]
                {
                    rp.IdCita,
                    rp.Paciente,
                    rp.Examen,
                    rp.Cantidad,



                });
            }

            dt.TableName = "Datos";
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reporte 6 " + DateTime.Now.ToString() + ".xlsx");
                }
            }
        }
        public JsonResult VerReporte7()
        {
            List<Reporte7> olista = new List<Reporte7>();
            olista = new CN_Reportes().ListarReporte7();
            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public FileResult ExportarReporte7()
        {
            List<Reporte7> oLista = new List<Reporte7>();
            oLista = new CN_Reportes().ListarReporte7();

            DataTable dt = new DataTable();
            dt.Locale = new System.Globalization.CultureInfo("es-PE");
            dt.Columns.Add("IdCita", typeof(int));
            dt.Columns.Add("Paciente", typeof(string));
            dt.Columns.Add("Medicamento", typeof(string));
            dt.Columns.Add("Cantidad", typeof(int));



            foreach (Reporte7 rp in oLista)
            {
                dt.Rows.Add(new object[]
                {
                    rp.IdCita,
                    rp.Paciente,
                    rp.Medicamento,
                    rp.Cantidad,



                });
            }

            dt.TableName = "Datos";
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reporte 7 " + DateTime.Now.ToString() + ".xlsx");
                }
            }
        }



    }
}