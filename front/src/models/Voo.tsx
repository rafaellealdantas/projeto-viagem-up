export interface Voo {
    Id: number;
    NumeroVoo: number;
    Origem?: string;
    Destino?: string;
    HrPartida?: string;
    HrChegadaPrevista?: string;
    TipoAviao?: string;
    Companhia?: string;
    TemProblema: boolean;
    VooCancelado: boolean;
}