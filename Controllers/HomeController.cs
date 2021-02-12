using DAW2P0.Business;
using DAW2P0.Models;
using DAW2P0.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DAW2P0.Controllers
{
    public class HomeController : MVCController
    {

        #region Pre-created stuff
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

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
        #endregion
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            dynamic showMessageString = string.Empty;
            if (usuario.user == null || !ServiceManager.GetUsuarioService().Autenticar(usuario))
            {
                showMessageString = new
                {
                    param1 = 404,
                    param2 = "Error en las credenciales"
                };
                return Json(showMessageString);
            }
            else
            {
                showMessageString = new
                {
                    param1 = 200,
                    param2 = "Usuario Correcto"
                };
                return Json(showMessageString);
            }
        }
    }
}
