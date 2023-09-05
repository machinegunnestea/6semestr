import React from "react";
import Header from "./components/UI/header/Header";
import "./styles/App.css"
import img from "./sample.jpg"
import Nav from "./components/UI/nav/Nav";
import Footer from "./components/UI/footer/Footer";
import {BrowserRouter} from "react-router-dom";
import AppRouter from "./components/AppRouter";

function App() {
  return(
      <BrowserRouter>
          <div className="App">
              <Header post={{title: "Фильмы", img: img}} />
              <Nav/>
              <AppRouter />
              <Footer name="Коваленко Анастасия Игоревна"/>
          </div>
      </BrowserRouter>


  );
}

export default App;
