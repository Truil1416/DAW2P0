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
    public class FormularioService : IFormularioService
    {
        private ServiceManager serviceManager;
        public FormularioService(ServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        public List<Formulario> getFormularios()
        {
            string path = @"Persistance\ArchivosPersistentes\Formularios.txt";
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
                    List<Formulario> formularios = JsonConvert.DeserializeObject<List<Formulario>>(contenido);
                    return formularios;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public void guardarFormulario(Formulario formulario)
        {
            //Guardamos el formulario
            //Soy un bruto y lo voy ha hacer leyendo un txt con jsons objects, agregando mi obj al json y escribiendo el txt entero de nuevo.
            //para salir del paso.
            string path = @"Persistance\ArchivosPersistentes\Formularios.txt";
            //string path = @"C:\Users\78595225Q\source\repos\DAW2P0\Persistance\ArchivosPersistentes\Formularios.txt";
            try {
                if (File.Exists(path))
                {
                    string contenido = "";
                    using (StreamReader sr = File.OpenText(path))
                    {
                        contenido = sr.ReadToEnd();
                    }
                    List<Formulario> formularios = JsonConvert.DeserializeObject<List<Formulario>>(contenido);
                    if (formularios == null) { formularios = new List<Formulario>(); }
                    formularios.Add(formulario);
                    using (FileStream fs = File.Create(path))
                    {
                        Byte[] datos = new UTF8Encoding(true).GetBytes(JsonConvert.SerializeObject(formularios));
                        fs.Write(datos,0,datos.Length);
                    }
                }
                else
                {
                    List<Formulario> formularios = new List<Formulario>();
                    formularios.Add(formulario);
                    using (FileStream fs = File.Create(path))
                    {
                        Byte[] datos = new UTF8Encoding(true).GetBytes(JsonConvert.SerializeObject(formularios));
                        fs.Write(datos, 0, datos.Length);
                    }
                }
            } 
            catch
            {

            }
        }

    }
}
