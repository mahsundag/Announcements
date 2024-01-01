import styles from "./pageTitle.module.css";

export const PageTitle = ({ children }) => {
  return (
    <div className={styles.container}>
      <div className={styles.title}>{children}</div>
    </div>
  );
};
