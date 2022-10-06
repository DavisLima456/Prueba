using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad1;
using CapaNegocio;

namespace CapaAsilo.Controllers
{
    public class LaboratorioController : Controller
    {
        // GET: Laboratorio
        public ActionResult Laboratorio()
        {
            return View();
        }

        public ActionResult AsignarExamenes()
        {
            return View();
        }


        //metodo para listar los examenes

        

        [HttpGet]
        public ActionResult ListarExamen()
        {

            List<DetalleCita> olista = new List<DetalleCita>();

            olista = new CN_Examen().Listar();


            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GuardarExamen(DetalleCita objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdDetalleCita == 0)
            {
                resultado = new CN_Examen().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Examen().Editar(objeto, out mensaje);

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult EliminarExamen(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new CN_Examen().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        //metodo para asignar resultados 

        [HttpPost]
        public JsonResult DarResultado(AsignarResultados objeto)
        {
            object resultado;
            string mensaje = string.Empty;


            resultado = new CN_CitasMedicas().DarResultado(objeto, out mensaje);



            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }


    }
}