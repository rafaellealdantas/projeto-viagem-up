using Microsoft.EntityFrameworkCore;

namespace ViagemProjeto.Models;

public class AppDbContext : DbContext
{
    // public DbSet<...> ... { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=nomeDoSeuBanco.db");
    }
}