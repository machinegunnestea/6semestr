import React from 'react';
import {BrowserRouter, Route, Routes} from "react-router-dom";
import Stars from "./pages/Stars";
import Tags from "./pages/Tags";
import Posts from "./pages/Posts";

const AppRouter = () => {
    return (
            <Routes>
                <Route path="/stars" element={<Stars/>}/>
                <Route path="/tags" element={<Tags/>}/>
                <Route path="/posts" element={<Posts/>}/>
            </Routes>
    );
};

export default AppRouter;