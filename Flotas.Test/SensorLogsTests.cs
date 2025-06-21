using Flotas.Modelos;

namespace Flotas.Test
{
    public class SensorLogsTests
    {
        [Fact]
        public void CrearSensorLog_ValoresValidos()
        {
            var log = new SensorLog
            {
                CamionId = 2,
                KilometrajeReportado = 21500,
                EstadoMotor = "Normal",
                FechaHora = DateTime.Now
            };

            Assert.Equal(2, log.CamionId);
            Assert.InRange(log.KilometrajeReportado, 0, 300000);
            Assert.Contains(log.EstadoMotor, new[] { "Normal", "Critico" });
        }
    }
}
