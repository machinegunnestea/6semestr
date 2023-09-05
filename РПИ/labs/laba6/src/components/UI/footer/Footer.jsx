import React from 'react';
import classes from './Footer.module.css'
const Footer = (props) => {
    return (
        <footer>
            {props.name}
        </footer>
    );
};

export default Footer;