using ControleEstoqueSementes.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoqueSementes.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=EstoquesSementes;Username=postgres;Password=123456");
        }
    }
}
