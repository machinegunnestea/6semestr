import React, { useState } from 'react';
import styles from "./Rating.module.css";

function Rating({ maxStars, selectedStars }) {
  const [selected, setSelected] = useState(selectedStars);

  const handleStarClick = (index) => {
    setSelected(index + 1);
    alert(`Выбранное кол-во звезд составляет ${index + 1}`);
  };

  const stars = [];

  for (let i = 0; i < maxStars; i++) {
    stars.push(
      <span
        key={i}
        className={i < selected ? `${styles.star} ${styles.selected}`: styles.star}
        onClick={() => handleStarClick(i)}
      >
        &#9733;
      </span>
    );
  }

  return <div className={styles.rating}>{stars}</div>;
}

export default Rating;