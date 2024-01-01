import styles from "./announcementItem.module.css";
import Link from "next/link";
import { format } from "date-fns";

export const AnnouncementItem = ({ date, title, description, slug }) => {
  return (
    <Link className={styles.container} href={`announcement/${slug}`}>
      <div className={styles.date}>{format(date, "dd.MM.yyyy")}</div>
      <div className={styles.content}>
        <div className={styles.title}>{title}</div>
        <p className={styles.description}>{description}</p>
      </div>
    </Link>
  );
};
