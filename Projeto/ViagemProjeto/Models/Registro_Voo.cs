namespace ViagemProjeto.Models;

public class Registro_Voo
{
    public int Id { get; set; }
    public int NumeroVoo { get; set; } 
    public string? Origem { get; set; }
    public string? Destino { get; set; }
    public string? HrPartida { get; set; }
    public string? HrChegadaPrevista { get; set; }
    public string? TipoAviao { get; set; }
    public string? Companhia { get; set; }
}
