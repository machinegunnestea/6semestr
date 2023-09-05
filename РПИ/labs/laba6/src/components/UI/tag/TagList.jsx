import React from 'react';
import Tag from "./Tag";
import cl from './Tag.module.css'

const TagList = ({tags}) => {
    return (
        <div className={cl.tagg}>
            {tags.map((tag)=>
                <Tag title={tag.title} href={tag.href} key={tag.id}/>
            )}
        </div>
    );
};

export default TagList;