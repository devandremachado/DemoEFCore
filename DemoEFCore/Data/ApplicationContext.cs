using DemoEFCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace DemoEFCore.Data
{
    public class ApplicationContext : DbContext
    {
        private static readonly ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole());

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder
                .UseLoggerFactory(_logger)
                .EnableSensitiveDataLogging()
                .UseSqlServer("Server=localhost;Database=DemoEF;User Id=sa;Password=q1w2e3;", p => p.EnableRetryOnFailure().MigrationsHistoryTable("DemoEFCore_Migrations"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Configura todas classes que herdam de IEntityTypeConfiguration
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);

            MepearPropriedadeStringTamanhoPadrao(builder);

        }

        /// <summary>
        /// Propriedades strings nao mapeadas serão varchar (250)
        /// </summary>
        /// <param name="builder"></param>
        private void MepearPropriedadeStringTamanhoPadrao(ModelBuilder builder)
        {
            foreach (var item in builder.Model.GetEntityTypes())
            {
                var propriedades = item.GetProperties().Where(p => p.ClrType == typeof(string));

                foreach (var prop in propriedades)
                {
                    if (string.IsNullOrEmpty(prop.GetColumnType()) && prop.GetMaxLength().HasValue == false)
                    {
                        prop.SetColumnType("VARCHAR(250)");
                    }
                }
            }
        }
    }
}
