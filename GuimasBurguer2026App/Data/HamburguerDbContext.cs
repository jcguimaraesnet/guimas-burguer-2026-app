using GuimasBurguer2026App.Models;
using Microsoft.EntityFrameworkCore;

namespace GuimasBurguer2026App.Data
{
    public class HamburguerDbContext : DbContext
    {
        public DbSet<Hamburguer> Hamburguer { get; set; }
        public DbSet<Marca> Marca { get; set; }

        protected override void OnConfiguring
        (
            DbContextOptionsBuilder optionsBuilder
        )
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string conn = config.GetConnectionString("MyDb");

            optionsBuilder.UseSqlServer(conn);
        }

    }
}
