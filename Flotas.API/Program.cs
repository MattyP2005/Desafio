using Microsoft.EntityFrameworkCore;
using Flotas.API.Data;
using Libreria.API.Services;

namespace Libreria.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Cadena de conexión desde appsettings.json
            var connectionStringSqlServer = builder.Configuration.GetConnectionString("SqlServerConnection");
            var connectionStringMariaDb = builder.Configuration.GetConnectionString("MariaDbConnection");

            // Registra DbContext para SQL Server
            builder.Services.AddDbContext<SqlServerDbContext>(options =>
                options.UseSqlServer(connectionStringSqlServer));

            // Registra DbContext para MariaDB
            builder.Services.AddDbContext<MariaDbContext>(options =>
                options.UseMySql(connectionStringMariaDb, ServerVersion.AutoDetect(connectionStringMariaDb)));

            // Servicios adicionales
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHostedService<MantenimientoPredictivoService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("PermitirTodo", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Middleware pipeline
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseCors("PermitirTodo");
            app.UseAuthorization();
            app.MapControllers();

            /* Migraciones automáticas (si aplica)
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var SqlServerContext = services.GetRequiredService<SqlServerDbContext>();
                SqlServerContext.Database.Migrate();

                var MariaDbContext = services.GetRequiredService<MariaDbContext>();
                MariaDbContext.Database.Migrate();
            }*/

            app.Run();
        }
    }
}
