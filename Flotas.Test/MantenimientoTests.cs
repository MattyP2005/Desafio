using Flotas.Modelos;

namespace Flotas.Test
{
    public class MantenimientoTests
    {
        [Fact]
        public void CrearMantenimiento_Valido()
        {
            var mantenimiento = new Mantenimiento
            {
                CamionId = 1,
                TallerId = 1,
                Fecha = DateTime.Today,
                Tipo = "Preventivo"
            };

            Assert.Equal("Preventivo", mantenimiento.Tipo);
            Assert.True(mantenimiento.Fecha <= DateTime.Today);
        }
    }
}
