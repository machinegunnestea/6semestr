import styles from "./Header.module.css";

const Header = ({ logoURL, title }) => {
  return (
    <header className={styles.header}>
      <img src={logoURL} alt="logo" />
      <span className={styles.title}>{title}</span>
    </header>
  );
};

export default Header;
