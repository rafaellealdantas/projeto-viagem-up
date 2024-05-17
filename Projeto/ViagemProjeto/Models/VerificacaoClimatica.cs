namespace ViagemProjeto.Models
{
    public class VerificacaoClimatica
    {
        public int Id { get; set; }
        public int NumeroVoo { get; set; }
        public string? RotaVoo { get; set; }
        public string? CondicoesMeteorologicas { get; set; }
        public string? PrevisaoTempo { get; set; }
        public string? AlertasTempestades { get; set; }
        public string? CondicoesAdversas { get; set; }
    }
}
