using Microsoft.AspNetCore.Mvc;
using TicketSystem.DTOs;

namespace TicketSystem.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CrearUsuario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Login", "Home");
            }

            return View(usuario);
        }
    }
}