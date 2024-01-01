"use client";
import { useParams } from "next/navigation";
import styles from "./announcementDetail.module.css";
import PageTitle from "@/app/components/PageTitle";
import { useEffect, useState } from "react";
import { getAnnouncementDetail } from "@/app/api/announcement";
import { format } from "date-fns";

const AnnouncementDetail = () => {
  const [announcement, setAnnouncement] = useState(null);
  const params = useParams();

  useEffect(() => {
    const fetchData = async () => {
      const res = await getAnnouncementDetail(params.slug);
      setAnnouncement(res);
      console.log(res);
    };
    fetchData();
  }, [params.slug]);

  return (
    <div className={styles.container}>
      <PageTitle>
        <h1>{announcement?.title}</h1>
        <p>
          {announcement?.date ? format(announcement?.date, "dd.MM.yyyy") : null}
        </p>
      </PageTitle>
      <div className={styles.content}>{announcement?.detail}</div>
    </div>
  );
};

export default AnnouncementDetail;
