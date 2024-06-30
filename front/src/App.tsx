import React from "react";
import VooListar from "./components/pages/voo/voo-listar";
import { BrowserRouter, Link, Routes, Route } from "react-router-dom";
import VooCadastrar from "./components/pages/voo/Voo-cadastrar";
import VooAlterar from "./components/pages/voo/Voo-alterar";

function App() {
  return (
    <div>
      <BrowserRouter>
        <nav>
          <ul>
            <li>
              <Link to="/">Home</Link>
            </li>
            <li>
              <Link to="/pages/voo/listar">Listar voos</Link>
            </li>
            <li>
              <Link to="/pages/voo/cadastrar">Cadastrar voos</Link>
            </li>
          </ul>
        </nav>
        <Routes>
          <Route path="/" element={<VooListar />} />
          <Route path="/pages/voo/listar" element={<VooListar />} />
          <Route path="/pages/voo/cadastrar" element={<VooCadastrar />} />
          <Route path="/pages/voo/alterar/:id" element={<VooAlterar />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
