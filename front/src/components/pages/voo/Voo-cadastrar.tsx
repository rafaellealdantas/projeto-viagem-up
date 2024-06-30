import { useState } from "react";
import { Voo } from "../../../models/Voo";
import { useNavigate } from "react-router-dom";
import "./styles.css";

function VooCadastrar() {
  const navigate = useNavigate();
  const [numeroVoo, setNumeroVoo] = useState("");
  const [origem, setOrigem] = useState("");
  const [destino, setDestino] = useState("");
  const [hrPartida, setHrPartida] = useState("");
  const [hrChegadaPrevista, setHrChegadaPrevista] = useState("");
  const [tipoAviao, setTipoAviao] = useState("");
  const [companhia, setCompanhia] = useState("");
  const [temProblema, setTemProblema] = useState(false);
  const [vooCancelado, setVooCancelado] = useState(false);

  function cadastrarVoo(e: any) {
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

    fetch("http://localhost:5281/api/registro_voo/cadastrar", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(voo),
    })
      .then((resposta) => resposta.json())
      .then((voo: Voo) => {
        navigate("/pages/voo/listar");
      });
    e.preventDefault();
  }

  return (
    <div className="container">
      <h1>Cadastrar Voo</h1>
      <form onSubmit={cadastrarVoo}>
        <label>Número do Voo:</label>
        <input
          type="number"
          placeholder="Digite o número do voo"
          onChange={(e) => setNumeroVoo(e.target.value)}
          required
        />
        <label>Origem:</label>
        <input
          type="text"
          placeholder="Digite a origem"
          onChange={(e) => setOrigem(e.target.value)}
          required
        />
        <label>Destino:</label>
        <input
          type="text"
          placeholder="Digite o destino"
          onChange={(e) => setDestino(e.target.value)}
          required
        />
        <label>Hora de Partida:</label>
        <input
          type="text"
          placeholder="Digite a hora de partida"
          onChange={(e) => setHrPartida(e.target.value)}
          required
        />
        <label>Hora de Chegada Prevista:</label>
        <input
          type="text"
          placeholder="Digite a hora de chegada prevista"
          onChange={(e) => setHrChegadaPrevista(e.target.value)}
          required
        />
        <label>Tipo de Avião:</label>
        <input
          type="text"
          placeholder="Digite o tipo de avião"
          onChange={(e) => setTipoAviao(e.target.value)}
          required
        />
        <label>Companhia:</label>
        <input
          type="text"
          placeholder="Digite a companhia"
          onChange={(e) => setCompanhia(e.target.value)}
          required
        />
        <label>Tem Problema:</label>
        <input
          type="checkbox"
          onChange={(e) => setTemProblema(e.target.checked)}
        />
        <label>Voo Cancelado:</label>
        <input
          type="checkbox"
          onChange={(e) => setVooCancelado(e.target.checked)}
        />
        <button type="submit">Cadastrar</button>
      </form>
    </div>
  );
}

export default VooCadastrar;
