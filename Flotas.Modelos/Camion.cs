using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotas.Modelos
{
    public class Camion
    {
        public int Id { get; set; }

        public int ConductorId { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public string Modelo { get; set; }

        public int Anio { get; set; }

        [Required]
        public string Placa { get; set; }

        public double KilometrajeActual { get; set; }

        public string Estado { get; set; }

    }
}
