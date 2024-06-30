import React from "react";
import VooListar from "./components/pages/voo/voo-listar";
import { BrowserRouter, Link, Routes, Route } from "react-router-dom";

function App() {
  return (
    <div>
      <BrowserRouter>
        <nav>
          <ul>
            <li>
              <Link to={"/"}>Home</Link>
            </li>
            <li>
              <Link to={"/pages/voo/listar"}>
                Listar voos{" "}
              </Link>
            </li>
          </ul>
        </nav>
        <Routes>
          <Route path="/" element={<VooListar />} />
          <Route
            path="/pages/voo/listar"
            element={<VooListar />}
          />
          
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
