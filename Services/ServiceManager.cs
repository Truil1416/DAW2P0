using DAW2P0.Services.Api;
using DAW2P0.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW2P0.Services
{
    public class ServiceManager
    {
        #region Servicios
        private IUsuarioService usuarioService;
        private IFormularioService formularioService;
        #endregion
        #region Constructor ServiceManager
        public ServiceManager()
        {
           
        }
        #endregion
        #region Implementación de las interfaces
        public IUsuarioService GetUsuarioService()
        {
            return usuarioService ?? (
                   usuarioService = new UsuarioService(this));
        }

        public IFormularioService GetFormularioService()
        {
            return formularioService ?? (
                   formularioService = new FormularioService(this));
        }
        #endregion
    }
}
