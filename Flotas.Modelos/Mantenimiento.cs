using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotas.Modelos
{
    public class Mantenimiento
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public string Tipo { get; set; }

        public int CamionId { get; set; }


        public int TallerId { get; set; }
    }
}
