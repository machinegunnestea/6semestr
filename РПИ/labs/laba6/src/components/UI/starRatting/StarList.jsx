import React, {useState} from 'react';
import './StarListt.css'

const StarList = (props) => {
    const [selectedStars, setSelectedStars] = useState(props.selectedStars || 0);
    const handleStarSelect=(selected)=>{
        setSelectedStars(selected)
        alert(`Selected ${selected} stars!`)
    }
    const starList=[]

    for(let i=1;i<=props.maxStars;i++){
        let className="star"

        if(i<=selectedStars){
             className+=" selected"
        }

        starList.push(
            <span key={i}
                  className={className}
                  onClick={() => handleStarSelect(i)}>
             &#9733;
        </span>);
    }
    return (
        <div className="stars">
            {starList}
        </div>
    );
};

export default StarList;