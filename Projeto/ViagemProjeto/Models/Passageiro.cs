namespace ViagemProjeto.Models;

public class Passageiro
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string NumeroDocumento { get; set; } = string.Empty;
    public DateOnly DataNascimento { get; set; }
    public string Nacionalidade { get; set; } = string.Empty;
    public string InformacoesContato { get; set; } = string.Empty;
    public string? Sobrenome { get; set; } // Propriedade opcional
    public string? Passaporte { get; set; } // Propriedade opcional
    public int VooId { get; set; }
    public Voo? Voo { get; set; }
}

