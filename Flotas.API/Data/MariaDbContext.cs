using Microsoft.EntityFrameworkCore;
using Flotas.Modelos;

namespace Flotas.API.Data
{
    public class MariaDbContext : DbContext
    {
        public MariaDbContext(DbContextOptions<MariaDbContext> options) : base(options) { }

        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<SensorLog> SensoresLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapear explícitamente las tablas en singular
            modelBuilder.Entity<Alerta>().ToTable("Alerta");
            modelBuilder.Entity<SensorLog>().ToTable("SensorLog");
        }
    }
}