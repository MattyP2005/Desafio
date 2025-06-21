namespace Flotas.Modelos
{
    public class Alerta
    {
        public int Id { get; set; }
        public string Mensaje { get; set; }
        public DateTime FechaGenerada { get; set; }
        public bool EsCritica { get; set; }

        public int CamionId { get; set; } 
    }
}
