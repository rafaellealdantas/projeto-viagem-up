namespace ViagemProjeto.Models;

public class Tripulacao
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Cargo { get; set; }
    public string? Funcao { get; set; }
    public string? Qualificacoes { get; set; }
    public string? HorarioTrabalho { get; set; }
    public string? IdiomasFalados { get; set; }
    public int VooId { get; set; }
    public Voo? Voo { get; set; }
}
