import React, {useState} from 'react';
import StarList from "../UI/starRatting/StarList";

const Stars = () => {
    return (
        <div>
            <StarList maxStars={5} selectedStars={3} />
        </div>
    );


};

export default Stars;