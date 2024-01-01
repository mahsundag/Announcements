import { AnnouncementItem } from "../AnnouncementItem/AnnouncementItem";
import styles from "./announcementList.module.css";

export const AnnouncementList = ({ announcements }) => {
  return (
    <div className={styles.container}>
      {announcements?.map((item) => (
        <AnnouncementItem
          key={item.id}
          date={item.date}
          title={item.title}
          description={item.shortText}
          slug={item.slug}
        />
      ))}
    </div>
  );
};
