using DAW2P0.Business;
using DAW2P0.Models;
using DAW2P0.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
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
        #region Login/LogOut
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
                //codigo del trabajo
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, usuario.user),
                    new Claim(ClaimTypes.NameIdentifier, usuario.user)
                };
                var userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8),
                };

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                HttpContext.Session.SetString("UsuarioLogin", usuario.user);
                //hasta aquí
                return Json(showMessageString);
            }
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        #endregion
        #region Manejo del Formulario
        [HttpPost]
        public IActionResult mandarFormulario(Formulario formulario)
        {
            ServiceManager.GetFormularioService().guardarFormulario(formulario);
            return RedirectToAction("Agradecimiento");
        }
        #endregion
        public IActionResult Agradecimiento()
        {
            return View();
        }
        public IActionResult Formularios()
        {
            return View(ServiceManager.GetFormularioService().getFormularios());
        }
    }
}
