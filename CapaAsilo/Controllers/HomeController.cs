using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad1;
using CapaNegocio;

namespace CapaAsilo.Controllers
{
    public class HomeController : Controller
    {
        #region VISTAS
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Donaciones()
        {
            return View();
        }

        public ActionResult Pagos()
        {
            return View();
        }
        #endregion

        //Donaciones
        #region DONACIONES
        [HttpGet]
        public ActionResult ListarDonaciones()
        {

            List<Donacion> olista = new List<Donacion>();

            olista = new CN_Donacion().Listar();


            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }

        // guardar donacion
        [HttpPost]
        public ActionResult GuardarDonaciones(Donacion objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdDonacion == 0)
            {
                resultado = new CN_Donacion().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Donacion().Editar(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EliminarDonaciones(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new CN_Donacion().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }
        #endregion

        //Pagos de Mensualidad
        #region MENSUALIDAD
        [HttpGet]
        public ActionResult ListarPagos()
        {

            List<Mensualidad> olista = new List<Mensualidad>();

            olista = new CN_PagoMensualidad().Listar();


            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }

        // guardar pago de mensualidad
        [HttpPost]
        public ActionResult GuardarPagos(Mensualidad objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdMensualidad == 0)
            {
                resultado = new CN_PagoMensualidad().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_PagoMensualidad().Editar(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EliminarPagos(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new CN_PagoMensualidad().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }
        #endregion

    }
}