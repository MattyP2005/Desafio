using Flotas.SensorSimulador.Models;
using System.Text;
using System.Text.Json;

namespace Flotas.SensorSimulador.Services
{
    public class SensorSender
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "https://localhost:5001/api/sensorlogs";

        public SensorSender()
        {
            _httpClient = new HttpClient();
        }

        public async Task EnviarLecturasPeriodicasAsync(CancellationToken cancellationToken)
        {
            var random = new Random();

            while (!cancellationToken.IsCancellationRequested)
            {
                var log = new SensorLog
                {
                    CamionId = random.Next(1, 4), // Simula camiones del 1 al 3
                    KilometrajeReportado = random.Next(18000, 26000),
                    EstadoMotor = random.Next(0, 2) == 0 ? "Normal" : "Critico",
                    FechaHora = DateTime.UtcNow
                };

                var json = JsonSerializer.Serialize(log);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    var res = await _httpClient.PostAsync(_apiUrl, content, cancellationToken);
                    Console.WriteLine($"[{DateTime.Now}] Enviado: {json} | Resultado: {res.StatusCode}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al enviar: {ex.Message}");
                }

                await Task.Delay(5000, cancellationToken); // Espera 5 segundos
            }
        }
    }
}
