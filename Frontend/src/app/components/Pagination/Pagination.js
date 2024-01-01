import styles from "./pagination.module.css";

export const Pagination = ({ count, setPageNumber, pageNumber, pageSize }) => {
  const paginationLength = Math.ceil(count / pageSize);
  return (
    
    <div className={styles.container}>
      <button
        className={styles.item}
        onClick={() => setPageNumber((prev) => prev - 1)}
        disabled={pageNumber < 2}
      >
        {"<"}
      </button>
      {[...Array(paginationLength)].map((item, index) => (
        <div
          className={styles.item}
          key={item}
          onClick={() => setPageNumber(index + 1)}
          style={{
            backgroundColor:
              pageNumber === index + 1
                ? "var(--color-primary)"
                : "var(--color-white)",
            color:
              pageNumber === index + 1
                ? "var(--color-white)"
                : "var(--color-text)",
          }}
        >
          {index + 1}
        </div>
      ))}

      <button
        className={styles.item}
        onClick={() => setPageNumber((prev) => prev + 1)}
        disabled={paginationLength <= pageNumber}
      >
        {">"}
      </button>
    </div>
  );
};
