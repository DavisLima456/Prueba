using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad1;
using CapaNegocio;

namespace CapaAsilo.Controllers
{
    public class FarmaciaController : Controller
    {
        // GET: Farmacia
        public ActionResult Farmacia()
        {
            return View();
        }
        public ActionResult Medicamentos()
        {
            return View();
        }

        //metodo para listar los Medicamentos



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




    }
}