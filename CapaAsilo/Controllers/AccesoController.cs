using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad1;
using CapaNegocio;



namespace CapaAsilo.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string correo, string clave, int rol)
                    {
            Usuario oUsuario = new Usuario();

            oUsuario = new CN_Usuario().Listar().Where(u => u.CORREO == correo && u.CLAVE == clave && u.ROL == rol).FirstOrDefault();
            if (oUsuario == null)
                {
                
                    ViewBag.Error = "Correo, Contraseña o Rol no Correcto";
                    return View();

                } 

            else if (oUsuario != null && rol == 1)

                {
                    ViewBag.Error = null;
                    return RedirectToAction("Index", "Home");
                } 

            else if (oUsuario != null && rol == 2)
                {
                    ViewBag.Error = null;
                    return RedirectToAction("Menu", "Medico");
                }
            else if (oUsuario != null && rol == 3)
            {
                ViewBag.Error = null;
                return RedirectToAction("HistorialEspecialista", "Especialista");
            }
            else if (oUsuario != null && rol == 4)
            {
                ViewBag.Error = null;
                return RedirectToAction("Laboratorio", "Laboratorio");
            }
            else if (oUsuario != null && rol == 5)
            {
                ViewBag.Error = null;
                return RedirectToAction("Farmacia", "Farmacia");
            }

            return View();
        }

        public ActionResult CerrarSesion()
        {
            return RedirectToAction("Index", "Acceso");
        }



       
    }
}