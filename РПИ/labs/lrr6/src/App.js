import React from 'react';
import logo from './logo.svg';
import './App.css';
import Navbar from './components/Navbar';
import { Route, Routes } from 'react-router-dom';
import Footer from './components/Footer';
import Posts from './components/Posts';
import Header from './components/Header';
import Rating from './components/Rating';
import Tags from './components/Tags';

function App() {
  let tagList=[
    { title: 'Google', href: 'https://www.google.com/'},
    { title: 'Метанит', href: 'https://metanit.com/web/javascript/'},
    { title: 'Справочник по реакту', href: 'https://ru.reactjs.org/'},
]

  return (
    <div className="App">
      <Header logoURL={logo}
        title="Приложение на реакте" />
      <Navbar />
      <Routes>
        <Route path="stars" element={<Rating maxStars={5} selectedStars={1} />}></Route>
        <Route path="tags" element={<Tags tags={tagList} />}></Route>
        <Route path="pagination" element={<Posts count={100} limit={10} />}></Route>
      </Routes>
      <Footer />
    </div>
  );
}

export default App;
