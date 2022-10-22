using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad1;
using CapaNegocio;

namespace CapaAsilo.Controllers
{
    public class PersonalController : Controller
    {
        // GET: Personal
        #region VISTAS
        public ActionResult Medico()
        {
            return View();
        }
        public ActionResult Enfermero()
        {
            return View();
        }
        #endregion

        #region MEDICO
        [HttpGet]
        public ActionResult ListarMedico()
        {

            List<Medico> olista = new List<Medico>();

            olista = new CN_Medico().Listar();


            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GuardarMedico(Medico objeto)
         {
            object resultado;
            string mensaje = string.Empty;
            if(objeto.IdMedico == 0)
            {
                resultado = new CN_Medico().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado= new CN_Medico().Editar(objeto, out mensaje);
            }

            return Json(new {resultado = resultado, mensaje= mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EliminarMedico(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty ;
            respuesta = new CN_Medico().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }
        #endregion

        // enfermero 
        #region ENFERMERO
        [HttpGet]
        public ActionResult ListarEnfermero()
        {

            List<Enfermero> olista = new List<Enfermero>();

            olista = new CN_Enfermero().Listar();


            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult GuardarEnfermero(Enfermero objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdEnfermero == 0)
            {
                resultado = new CN_Enfermero().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Enfermero().Editar(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EliminarEnfermero(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new CN_Enfermero().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        #endregion


    }
}