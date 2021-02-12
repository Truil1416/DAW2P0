using DAW2P0.Business;
using DAW2P0.Services.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            //acceso a la base de datos y comprobar las credenciales.
            //return ((usuario.password == "1234" && usuario.user == "admin")|| (usuario.password == "pepe" && usuario.user == "pepe"));
            string path = @"Persistance\ArchivosPersistentes\Usuarios.txt";
            //string path = @"C:\Users\78595225Q\source\repos\DAW2P0\Persistance\ArchivosPersistentes\Formularios.txt";
            try
            {
                if (File.Exists(path))
                {
                    string contenido = "";
                    using (StreamReader sr = File.OpenText(path))
                    {
                        contenido = sr.ReadToEnd();
                    }
                    List<Usuario> usuarios = JsonConvert.DeserializeObject<List<Usuario>>(contenido);
                    if (usuarios == null) { return false; }
                    bool aux = false;
                    usuarios.ForEach(e => { if (e.password == usuario.password && e.user == usuario.user) { aux = true; } });
                    return aux;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
    }
}
