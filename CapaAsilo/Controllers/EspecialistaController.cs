using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad1;
using CapaNegocio;


namespace CapaAsilo.Controllers
{
    public class EspecialistaController : Controller
    {
        // GET: Especialista
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AsignarMedicina()
        {
            return View();
        }

        public ActionResult HistorialEspacialista()
        {
            return View();
        }

        //para listar los costos
        [HttpGet]
        public JsonResult ListaCostoMedicos(int IdCita)
        {
            List<CostoMedico> olista = new List<CostoMedico>();
            olista = new CN_CostosMedico().ListaCostoMedicos(IdCita);
            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }

        //para listar los medicamentos
        [HttpGet]
        public JsonResult ListaMedicamentos(int IdCita)
        {
            List<CostoMedico> olista = new List<CostoMedico>();
            olista = new CN_CostosMedico().ListaMedicamentos(IdCita);
            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }

        //eliminar un costo
        [HttpPost]
        public JsonResult EliminarCosto(int id, int i)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_CostosMedico().Eliminar(id, i, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


        //para visualizar la info del paciente

        public JsonResult List_Paciente(int IdCita)
        {
            VerPaciente objeto = new CN_CostosMedico().List_Paciente(IdCita);
            return Json(new { resultado = objeto }, JsonRequestBehavior.AllowGet);

        }

        //para guardar la asignacion de examenes
        [HttpPost]
        public JsonResult RegistrarCosto(CostoMedico objeto)
        {

            object resultado;
            string mensaje = string.Empty;


            resultado = new CN_CostosMedico().Registrar(objeto, out mensaje);



            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }

        //metodo para listar la agenda del dia

        [HttpGet]
        public JsonResult listarAgenda(int IdEspecialista)
        {
            List<ListarAgenda> olista = new List<ListarAgenda>();
            olista = new CN_ListarAgenda().listarAgenda(IdEspecialista);
            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }


    }
}