using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad1;
using CapaNegocio;

namespace CapaAsilo.Controllers
{
    public class MedicoController : Controller
    {
        // GET: Medico
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



        // metodos

        //ficha
        public JsonResult VerFichaMedica(int IdCita)
        {
            Ficha objeto = new CN_Ficha().VerFicha(IdCita);
            return Json(new { resultado = objeto }, JsonRequestBehavior.AllowGet);

        }


        // citas
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


        //citas fin

        //pacientes

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


    }
}