using DAW2P0.Business;
using DAW2P0.Services.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW2P0.Services.Impl
{
    public class FormularioService : IFormularioService
    {
        private ServiceManager serviceManager;
        public FormularioService(ServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        public void guardarFormulario(Formulario formulario)
        {
            //Guardamos el formulario
        }

    }
}
