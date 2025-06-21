using Flotas.SensorSimulador.Services;

Console.WriteLine("Simulador de sensores iniciado. Presiona Ctrl+C para salir.");

using var cts = new CancellationTokenSource();
Console.CancelKeyPress += (s, e) =>
{
    e.Cancel = true;
    cts.Cancel();
    Console.WriteLine("Cancelando...");
};

var sender = new SensorSender();
await sender.EnviarLecturasPeriodicasAsync(cts.Token);

Console.WriteLine("Simulador detenido.");
