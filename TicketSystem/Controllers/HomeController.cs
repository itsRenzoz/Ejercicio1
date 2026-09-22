using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TicketSystem.Models;
using TicketSystem.DTOs; 

namespace TicketSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(Usuario usuario)
        {
            if(!ModelState.IsValid) {
                return View(usuario); 
            } else
            {
                string usuarioCorrecto = "admin";
                string passwordCorrecto = "Cinema123@";

                if (usuario.nombre_usuario == usuarioCorrecto && usuario.password == passwordCorrecto)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "El usuario indicado no existe";
                }

                return View();
            }

        }

        //Landing 
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}