import React, { useState } from 'react';
import {Link } from "react-router-dom";
import styles from "./Navbar.module.css";

const Navbar = () => {
  return (
    <div className={styles.navbar}>
      <div className={styles.item}>
        <Link to="/stars">рейтинг</Link>
      </div>
      <div className={styles.item}>
        <Link to="/tags">Теги</Link>
      </div>
      <div className={styles.item}>
        <Link to="/pagination">посты</Link>
      </div>
    </div>
  );
};

export default Navbar;
