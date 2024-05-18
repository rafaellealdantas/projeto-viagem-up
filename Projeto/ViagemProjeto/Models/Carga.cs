namespace ViagemProjeto.Models;
public class Carga
{
    
    public int Id { get; set; }
    public double Peso { get; set; }
    public string? Descricao { get; set; }
    public DateTime DataDeEmbarque { get; set; } = DateTime.Now;
    public bool CargaPrioritaria { get; set; }
    public bool CargaComercial { get; set; }
    public int PassageiroId { get; set; }
    public Passageiro? Passageiro { get; set; }
}