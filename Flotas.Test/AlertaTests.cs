using Flotas.Modelos;

namespace Flotas.Test
{
    public class AlertaTests
    {
        [Fact]
        public void CrearAlerta_ValoresValidos()
        {
            var alerta = new Alerta
            {
                CamionId = 1,
                FechaGenerada = DateTime.Now,
                Mensaje = "Mantenimiento urgente",
                EsCritica = true
            };
            Assert.True(alerta.EsCritica);
            Assert.Contains("urgente", alerta.Mensaje.ToLower());
        }
    }
}
