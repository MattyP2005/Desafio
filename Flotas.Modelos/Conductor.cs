using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotas.Modelos
{
    public class Conductor
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Licencia { get; set; }

        public DateTime FechaVencimiento { get; set; }
    }
}