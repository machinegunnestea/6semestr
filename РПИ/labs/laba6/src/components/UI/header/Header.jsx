import React from 'react';
import classes from './Header.module.css'

const Header = (props) => {
    return (
        <header className={classes.div}>
            <img className={classes.myImg} src={props.post.img} alt="img"/>
            <h1 className={classes.myTitile}> {props.post.title}</h1>
        </header>
    );
};

export default Header;