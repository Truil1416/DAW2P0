using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAW2P0.Business
{
    public class Formulario
    {
        [Required]
        public String nombre { get; set; }
        [Required]
        public String primerApellido { get; set; }
        [Required]
        public String segundoApellido { get; set; }
        public String opinion { get; set; }
    }
}
