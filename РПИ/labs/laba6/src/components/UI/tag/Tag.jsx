import React from 'react';
import cl from './Tag.module.css'
const Tag = ({title, href}) => {
    return (
        <a className={cl.tag} href={href}>
            {title}
        </a>
    );
};

export default Tag;