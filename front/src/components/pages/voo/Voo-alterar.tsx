import { useEffect, useState } from "react";
import { Voo } from "../../../models/Voo";
import { useNavigate, useParams } from "react-router-dom";

function VooAlterar() {
  const navigate = useNavigate();
  const { id } = useParams();
  const [numeroVoo, setNumeroVoo] = useState("");
  const [origem, setOrigem] = useState("");
  const [destino, setDestino] = useState("");
  const [hrPartida, setHrPartida] = useState("");
  const [hrChegadaPrevista, setHrChegadaPrevista] = useState("");
  const [tipoAviao, setTipoAviao] = useState("");
  const [companhia, setCompanhia] = useState("");
  const [temProblema, setTemProblema] = useState(false);
  const [vooCancelado, setVooCancelado] = useState(false);

  useEffect(() => {
    if (id) {
      fetch(`http://localhost:5281/api/registro_voo/buscar/${id}`)
        .then((resposta) => {
          if (!resposta.ok) {
            throw new Error('Network response was not ok');
          }
          return resposta.json();
        })
        .then((voo: Voo) => {
          setNumeroVoo(voo.numeroVoo.toString());
          setOrigem(voo.origem ?? "");
          setDestino(voo.destino ?? "");
          setHrPartida(voo.hrPartida ?? "");
          setHrChegadaPrevista(voo.hrChegadaPrevista ?? "");
          setTipoAviao(voo.tipoAviao ?? "");
          setCompanhia(voo.companhia ?? "");
          setTemProblema(voo.temProblema);
          setVooCancelado(voo.vooCancelado);
        })
        .catch((error) => {
          console.error('Houve um problema com a solicitação:', error);
        });
    }
  }, [id]);

  function alterarVoo(e: any) {
    e.preventDefault();
    
    const voo: Voo = {
      numeroVoo: parseInt(numeroVoo),
      origem: origem,
      destino: destino,
      hrPartida: hrPartida,
      hrChegadaPrevista: hrChegadaPrevista,
      tipoAviao: tipoAviao,
      companhia: companhia,
      temProblema: temProblema,
      vooCancelado: vooCancelado,
    };

    fetch(`http://localhost:5281/api/registro_voo/atualizar/${id}`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(voo),
    })
      .then((resposta) => {
        if (!resposta.ok) {
          throw new Error('Network response was not ok');
        }
        return resposta.json();
      })
      .then((data) => {
        console.log("Resposta da API:", data);
        navigate("/pages/voo/listar");
      })
      .catch((error) => {
        console.error('Houve um problema com a solicitação:', error);
      });
  }

  return (
    <div>
      <h1>Alterar Voo</h1>
      <form onSubmit={alterarVoo}>
        <label>Número do Voo:</label>
        <input
          type="number"
          placeholder="Digite o número do voo"
          value={numeroVoo}
          onChange={(e: any) => setNumeroVoo(e.target.value)}
          required
        />
        <br />
        <label>Origem:</label>
        <input
          type="text"
          placeholder="Digite a origem"
          value={origem}
          onChange={(e: any) => setOrigem(e.target.value)}
          required
        />
        <br />
        <label>Destino:</label>
        <input
          type="text"
          placeholder="Digite o destino"
          value={destino}
          onChange={(e: any) => setDestino(e.target.value)}
          required
        />
        <br />
        <label>Hora de Partida:</label>
        <input
          type="text"
          placeholder="Digite a hora de partida"
          value={hrPartida}
          onChange={(e: any) => setHrPartida(e.target.value)}
          required
        />
        <br />
        <label>Hora de Chegada Prevista:</label>
        <input
          type="text"
          placeholder="Digite a hora de chegada prevista"
          value={hrChegadaPrevista}
          onChange={(e: any) => setHrChegadaPrevista(e.target.value)}
          required
        />
        <br />
        <label>Tipo de Avião:</label>
        <input
          type="text"
          placeholder="Digite o tipo de avião"
          value={tipoAviao}
          onChange={(e: any) => setTipoAviao(e.target.value)}
          required
        />
        <br />
        <label>Companhia:</label>
        <input
          type="text"
          placeholder="Digite a companhia"
          value={companhia}
          onChange={(e: any) => setCompanhia(e.target.value)}
          required
        />
        <br />
        <label>Tem Problema:</label>
        <input
          type="checkbox"
          checked={temProblema}
          onChange={(e: any) => setTemProblema(e.target.checked)}
        />
        <br />
        <label>Voo Cancelado:</label>
        <input
          type="checkbox"
          checked={vooCancelado}
          onChange={(e: any) => setVooCancelado(e.target.checked)}
        />
        <br />
        <button type="submit">Alterar</button>
      </form>
    </div>
  );
}

export default VooAlterar;
