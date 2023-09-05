import React from 'react';
import classes from './Nav.module.css'
import {Link} from "react-router-dom";

const Nav = () => {
    return (
        <nav className={classes.MyDiv}>
            <button className={classes.MyButton}>
                <Link to="/stars">1</Link>
            </button>
            <button className={classes.MyButton}>
                <Link to="/tags">2</Link>
            </button>
            <button className={classes.MyButton}>
                <Link to="/posts">3</Link>
            </button>
        </nav>
    );
};

export default Nav;