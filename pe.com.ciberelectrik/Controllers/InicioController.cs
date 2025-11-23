using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pe.com.ciberelectrik.Controllers
{
    public class InicioController : Controller
    {
        private bdciberelectrik2026Entities db = new bdciberelectrik2026Entities();

        // GET: Inicio
        public ActionResult Index()
        {
            return View();
        }

        //creamos una funcion para validar
        [HttpPost]
        public ActionResult ValidarUsuario(string usuario, string clave)
        {
            if (string.IsNullOrEmpty(usuario))
            {
                ViewBag.Mensaje = "Ingrese el usuario";
                return View("Index");
            }
            else if (string.IsNullOrEmpty(clave)) {
                ViewBag.Mensaje = "Ingrese la clave";
                return View("Index");
            }
            else
            {
                //verificamos el usuario y la clave
                var empleado = db.empleado.FirstOrDefault(
                    e=> e.usuemp==usuario && e.claemp==clave
                    );
                if (empleado != null) {
                    //guardamos la sesion
                    Session["empleado"] = empleado;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Mensaje = "Usuario o Clave incorrecta";
                    return View("Index");
                }
            }
        }
    }
}
