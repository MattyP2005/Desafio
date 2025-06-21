using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotas.Modelos
{
    public class Taller
    {
        public int Id { get; set; }

      
        public string Nombre { get; set; }

        public string Ciudad { get; set; }

        public int CapacidadMaxima { get; set; }

        
    }
}