using DAW2P0.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW2P0.Controllers
{
    public class MVCController : Controller
    {
        #region Inicialización del controlador de página
        private readonly ServiceManager serviceManager;
        public MVCController()
        {
            serviceManager = new ServiceManager();

        }
        protected ServiceManager ServiceManager
        {
            get
            {
                return serviceManager;
            }
        }
        #endregion
    }
}
