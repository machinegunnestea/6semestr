import React, {useState} from 'react';
import TagList from "../UI/tag/TagList";

const Tags = () => {
    const [tags, setTegs]=useState([
        {title: "All", href: "http://link1.ru"},
        {title: "Large", href:"http://link2.ru" },
        {title: "Size", href:"http://link1.ru" }
    ]);
    return (
        <TagList tags={tags}/>
    );
};

export default Tags;