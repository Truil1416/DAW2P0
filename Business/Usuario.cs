using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAW2P0.Business
{
    public class Usuario
    {
        public String user { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public String password { get; set; }
    }
}
