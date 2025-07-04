using Metafinkend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Metafinkend.Controllers
{
    public class CuentaController : Controller
    {
        private readonly MercyDeveloper2Context db;

        public CuentaController(MercyDeveloper2Context context)
        {
            db = context;
        }

        // GET: /Cuenta/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Cuenta/Login
        [HttpPost]
        public IActionResult Login(string correo, string password)
        {
            var Usuarios = db.Usuarios.FirstOrDefault(c => c.Correo == correo && c.Password == password);

            if (Usuarios != null)
            {
                HttpContext.Session.SetString("UsuarioCorreo", Usuarios.Correo);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Mensaje = "Correo o contraseña incorrectos.";
            return View();
        }

        public IActionResult VistaSegura()
{
    if (HttpContext.Session.GetString("UsuarioCorreo") == null)
    {
        return RedirectToAction("Login", "Cuenta");
    }

    return View();
}
    }
}
  