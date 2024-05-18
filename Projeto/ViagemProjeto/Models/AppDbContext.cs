using Microsoft.EntityFrameworkCore;
namespace ViagemProjeto.Models;


public class AppDbContext : DbContext
{
    public DbSet<Voo> Voos { get; set; }
    public DbSet<Tripulacao> Tripulacoes { get; set; }
    public DbSet<Clima> Climas { get; set; }
    public DbSet<Passageiro> Passageiros { get; set; }
    public DbSet<Carga> Cargas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=projeto_viagem.db");
    }
}

