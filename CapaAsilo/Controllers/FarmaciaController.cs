using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CapaEntidad1;
using CapaEntidad1.Paypal;
using CapaNegocio;

namespace CapaAsilo.Controllers
{
    public class FarmaciaController : Controller
    {
        // GET: Farmacia
        #region FARMACIA
        public ActionResult Farmacia()
        {
            return View();
        }
        public ActionResult Medicamentos()
        {
            return View();
        }
        #endregion


        #region MEDICAMENTOS

        [HttpGet]
        public ActionResult ListarMedicamento()
        {

            List<DetalleCita> olista = new List<DetalleCita>();

            olista = new CN_Medicamentos().Listar();


            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GuardarMedicamento(DetalleCita objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdDetalleCita == 0)
            {
                resultado = new CN_Medicamentos().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Medicamentos().Editar(objeto, out mensaje);

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult EliminarMedicamento(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new CN_Medicamentos().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        #endregion


        #region DETALLE DE CITAS

        [HttpGet]
        public JsonResult DetalleCita(int IdCita)
        {
            List<VistaCita> olista = new List<VistaCita>();
            olista = new CN_CostosMedico().DetalleCita(IdCita);
            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Totalcita(int IdCita)
        {
            TotalCita objeto = new CN_CostosMedico().Totalcita(IdCita);
            return Json(new { resultado = objeto }, JsonRequestBehavior.AllowGet);

        }
        public JsonResult VerCitas(int IdCita)
        {
            VerCitas objeto = new CN_CostosMedico().VerCitas(IdCita);
            return Json(new { resultado = objeto }, JsonRequestBehavior.AllowGet);

        }

        #endregion

       
        public JsonResult enviarCorreo(string correo, string total)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = CN_EnviarCorreo.Enviar(correo, total, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


    }
}