﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotas.Modelos
{
    public class SensorLog
    {
        public int Id { get; set; }

        public int CamionId { get; set; }

        public DateTime FechaHora { get; set; }

        public double KilometrajeReportado { get; set; }

        public string EstadoMotor { get; set; }
    }
}