using Flotas.API.Data;
using Flotas.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Libreria.API.Services
{
    public class MantenimientoPredictivoService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<MantenimientoPredictivoService> _logger;

        public MantenimientoPredictivoService(IServiceProvider serviceProvider, ILogger<MantenimientoPredictivoService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Servicio de mantenimiento predictivo iniciado.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var mariaDb = scope.ServiceProvider.GetRequiredService<MariaDbContext>();

                        var sensores = await mariaDb.SensoresLogs
                            .OrderByDescending(s => s.FechaHora)
                            .GroupBy(s => s.CamionId)
                            .Select(g => g.First())
                            .ToListAsync();

                        foreach (var log in sensores)
                        {
                            bool esCritica = false;
                            string mensaje = "";

                            if (log.KilometrajeReportado >= 20000)
                            {
                                esCritica = true;
                                mensaje += $"Kilometraje alto: {log.KilometrajeReportado} km. ";
                            }

                            if (!string.IsNullOrEmpty(log.EstadoMotor) &&
                                log.EstadoMotor.ToLower().Contains("critico"))
                            {
                                esCritica = true;
                                mensaje += $"Estado del motor: {log.EstadoMotor}. ";
                            }

                            if (esCritica)
                            {
                                var alertaExistente = await mariaDb.Alertas
                                    .AnyAsync(a => a.CamionId == log.CamionId &&
                                                   a.Mensaje == mensaje &&
                                                   a.FechaGenerada.Date == DateTime.UtcNow.Date);

                                if (!alertaExistente)
                                {
                                    var alerta = new Alerta
                                    {
                                        CamionId = log.CamionId,
                                        Mensaje = mensaje,
                                        EsCritica = true,
                                        FechaGenerada = DateTime.UtcNow
                                    };

                                    mariaDb.Alertas.Add(alerta);
                                    await mariaDb.SaveChangesAsync();

                                    _logger.LogInformation($"⚠️ Alerta creada para Camión {log.CamionId}: {mensaje}");
                                }
                            }
                        }
                    }

                    // Esperar 60 segundos antes de la próxima revisión
                    await Task.Delay(TimeSpan.FromSeconds(60), stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error en el servicio de mantenimiento predictivo.");
                    await Task.Delay(5000, stoppingToken); // esperar antes de intentar de nuevo
                }
            }

            _logger.LogInformation("Servicio de mantenimiento predictivo detenido.");
        }
    }
}