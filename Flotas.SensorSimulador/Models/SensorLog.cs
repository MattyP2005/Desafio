
namespace Flotas.SensorSimulador.Models
{
    public class SensorLog
    {
        public int CamionId { get; set; }
        public double KilometrajeReportado { get; set; }
        public string EstadoMotor { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
