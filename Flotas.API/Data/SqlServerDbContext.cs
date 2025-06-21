using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Flotas.Modelos;

namespace Flotas.API.Data
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options) { }

        public DbSet<Camion> Camiones { get; set; }
        public DbSet<Conductor> Conductores { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
        public DbSet<Taller> Talleres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapeo explícito de tablas con nombres exactos en la base de datos
            modelBuilder.Entity<Camion>().ToTable("Camion");
            modelBuilder.Entity<Conductor>().ToTable("Conductor");
            modelBuilder.Entity<Mantenimiento>().ToTable("Mantenimiento");
            modelBuilder.Entity<Taller>().ToTable("Taller");
        }
    }
}