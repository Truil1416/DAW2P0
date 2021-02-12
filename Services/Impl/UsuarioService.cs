using DAW2P0.Business;
using DAW2P0.Services.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW2P0.Services.Impl
{
    public class UsuarioService : IUsuarioService
    {
        private ServiceManager serviceManager;
        public UsuarioService(ServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        public bool Autenticar(Usuario usuario)
        {
            return true;
        }
    }
}
