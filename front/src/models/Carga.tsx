export interface Carga {
    id: number;
    peso: number;
    descricao?: string;
    cargaPrioritaria: boolean;
    cargaComercial: boolean;
    passageiroId: number;
}