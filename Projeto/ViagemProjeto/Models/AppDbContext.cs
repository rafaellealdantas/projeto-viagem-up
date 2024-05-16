using Microsoft.EntityFrameworkCore;

namespace ViagemProjeto.Models;

public class AppDbContext : DbContext
{
    public DbSet<Registro_Voo> Registro_Voos { get; set; }
    public DbSet<Registro_Tripulacao> Registro_Tripulacoes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=projeto_viagem.db");
    }
}