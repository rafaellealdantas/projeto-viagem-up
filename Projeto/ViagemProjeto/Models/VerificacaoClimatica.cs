namespace ViagemProjeto.Models;
public class VerificacaoClimatica
{
    public int Id { get; set; }
    public string? CondicoesMeteorologicas { get; set; }
    public string? PrevisaoTempo { get; set; }
    public string? AlertasTempestades { get; set; }
    public string? CondicoesAdversas { get; set; }
    public int VooId { get; set; }
    public Voo? Voo { get; set; }
}


