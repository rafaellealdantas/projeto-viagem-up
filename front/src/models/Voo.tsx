export interface Voo {
    id?: number;
    numeroVoo: number;
    origem?: string;
    destino?: string;
    hrPartida?: string;
    hrChegadaPrevista?: string;
    tipoAviao?: string;
    companhia?: string;
    temProblema: boolean;
    vooCancelado: boolean;
}