import { useEffect, useState } from "react";
import { Voo } from "../../../models/Voo";
import { Link } from "react-router-dom";

function VooListar() {
  const [Voo, setVoos] = useState<Voo[]>([]);

  useEffect(() => {
    carregarVoos();
  }, []);

  function carregarVoos() {
    //FETCH ou AXIOS
    fetch("http://localhost:5281/api/registro_voo/listar")
      .then((resposta) => resposta.json())
      .then((voo: Voo[]) => {
        console.table(voo);
        setVoos(voo);
      });
  }

return (
    <div>
        <h1>Listar Voos</h1>
        <table border={1}>
            <thead>
                <tr>
                    <th>#</th>
                    <th>Número do Voo</th>
                    <th>Origem</th>
                    <th>Destino</th>
                    <th>Hora de Partida</th>
                    <th>Hora de Chegada Prevista</th>
                    <th>Tipo de Avião</th>
                    <th>Companhia</th>
                    <th>Tem Problema</th>
                    <th>Voo Cancelado</th>
                    <th>Criado Em</th>
                    <th>Deletar</th>
                    <th>Alterar</th>
                </tr>
            </thead>
            <tbody>
                {Voo.map((voo) => (
                    <tr key={voo.id}>
                        <td>{voo.id}</td>
                        <td>{voo.numeroVoo}</td>
                        <td>{voo.origem}</td>
                        <td>{voo.destino}</td>
                        <td>{voo.hrPartida}</td>
                        <td>{voo.hrChegadaPrevista}</td>
                        <td>{voo.tipoAviao}</td>
                        <td>{voo.companhia}</td>
                        <td>{voo.temProblema ? "Sim" : "Não"}</td>
                        <td>{voo.vooCancelado ? "Sim" : "Não"}</td>
                        {/* <td>
                            <button
                                onClick={() => {
                                    deletar(voo.id!);
                                }}
                            >
                                Deletar
                            </button>
                        </td> */}
                        {/* <td>
                            <Link to={`/pages/Voo/alterar/${voo.id}`}>
                                Alterar
                            </Link>
                        </td> */}
                    </tr>
                ))}
            </tbody>
        </table>
    </div>
);
}

export default VooListar;
