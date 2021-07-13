using DemoEFCore.Data.Configurations;
using DemoEFCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoEFCore.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=localhost;Database=DemoEF;User Id=sa;Password=q1w2e3;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}
