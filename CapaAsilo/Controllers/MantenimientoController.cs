using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad1;
using CapaNegocio;

namespace CapaAsilo.Controllers
{
    public class MantenimientoController : Controller
    {
        // GET: Mantenimiento
        public ActionResult Usuarios()
        {
            return View();
        }
        public ActionResult Especialista()
        {
            return View();
        }
        public ActionResult Especialidad()
        {
            return View();
        }
        public ActionResult Turno()
        {
            return View();
        }
        public ActionResult EstadoCita()
        {
            return View();
        }
        public ActionResult Fundacion() { 
            return View();
        }
        public ActionResult Mes()
        {
            return View();
        }
        public ActionResult Gastos()
        {
            return View();
        }
        //usuarios
        [HttpGet]
        public ActionResult ListarUsuarios()
        {

            List<Usuario> olista = new List<Usuario>();

            olista = new CN_Usuario().Listar();


            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }

        // guardar usuario
        [HttpPost]
        public ActionResult GuardarUsuario(Usuario objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.ID_USUARIO == 0)
            {
                resultado = new CN_Usuario().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Usuario().Editar(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EliminarUsuario(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new CN_Usuario().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }



        //Especialidad
        [HttpGet]
        public ActionResult ListarEspecialidad()
        {

            List<Especialidad> olista = new List<Especialidad>();

            olista = new CN_Especialidad().Listar();


            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GuardarEspecialidad(Especialidad objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdEspecialidad == 0)
            {
                resultado = new CN_Especialidad().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Especialidad().Editar(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EliminarEspecialidad(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new CN_Especialidad().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        // especialista
        [HttpGet]
        public ActionResult ListarEspecialista()
        {

            List<Especialista> olista = new List<Especialista>();

            olista = new CN_Especialista().Listar();


            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GuardarEspecialista (Especialista objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdEspecialista == 0)
            {
                resultado = new CN_Especialista().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Especialista().Editar(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EliminarEspecialista(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new CN_Especialista().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }


        //Turno

        [HttpGet]
        public ActionResult ListarTurno()
        {

            List<Turno> olista = new List<Turno>();

            olista = new CN_Turno().Listar();


            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GuardarTurno(Turno objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.NoTurno == 0)
            {
                resultado = new CN_Turno().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Turno().Editar(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EliminarTurno(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new CN_Turno().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }


        //estados de citas
        [HttpGet]
        public ActionResult ListarEstados()
        {

            List<Estado> olista = new List<Estado>();

            olista = new CN_Estados().Listar();


            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GuardarEstado(Estado objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdEstado == 0)
            {
                resultado = new CN_Estados().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Estados().Editar(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EliminarEstado(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new CN_Estados().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }



        //Fundacion
        [HttpGet]
        public ActionResult ListarFundacion()
        {

            List<Fundacion> olista = new List<Fundacion>();

            olista = new CN_Fundacion().Listar();


            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GuardarFundacion(Fundacion objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdFundacion == 0)
            {
                resultado = new CN_Fundacion().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Fundacion().Editar(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EliminarFundacion(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new CN_Fundacion().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        //fundacion
        [HttpGet]
        public ActionResult ListarMeses()
        {

            List<Mes> olista = new List<Mes>();

            olista = new CN_Mes().Listar();


            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GuardarMes(Mes objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdMes == 0)
            {
                resultado = new CN_Mes().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Mes().Editar(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EliminarMes(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new CN_Mes().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        //Gastos Generales
        public ActionResult ListarGastos()
        {

            List<GastosGenerales> olista = new List<GastosGenerales>();

            olista = new CN_GastosGenerales().Listar();


            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GuardarGastos(GastosGenerales objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdGastosGenerales == 0)
            {
                resultado = new CN_GastosGenerales().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_GastosGenerales().Editar(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EliminarGastos(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new CN_GastosGenerales().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }


    }
}