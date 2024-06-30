export interface Passageiro {
    Id: number;
    Nome: string;
    NumeroDocumento: string;
    DataNascimento: Date;
    Nacionalidade: string;
    InformacoesContato: string;
    Sobrenome?: string;
    Passaporte?: string;
    VooId: number;
}