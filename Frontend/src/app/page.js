"use client";

import Image from "next/image";
import AnnouncementList from "./components/AnnouncementList";
import PageTitle from "./components/PageTitle";
import styles from "./page.module.css";
import { useEffect, useState } from "react";
import { getAnnouncementList } from "./api/announcement";
import Pagination from "./components/Pagination";

const PAGE_SIZE = 10;

export default function Home() {
  const [announcementList, setAnnouncementList] = useState(null);
  const [pageNumber, setPageNumber] = useState(1);
  const [count, setCount] = useState(0);
  useEffect(() => {
    const fetchData = async () => {
      const announcements = await getAnnouncementList({
        pageNumber: pageNumber,
        pageSize: PAGE_SIZE,
      });
      setAnnouncementList(announcements.data);
      setCount(announcements.count);
    };

    fetchData();
  }, [pageNumber]);

  return (
    <main>
      <PageTitle>
        <div className={styles.title}>
          <Image
            src="/icons/announcement.png"
            alt="announcement icon"
            width={36}
            height={36}
          />
          <h1>Announcements</h1>
        </div>
      </PageTitle>
      {announcementList ? (
        <>
          <AnnouncementList announcements={announcementList} />
          <Pagination
            pageNumber={pageNumber}
            setPageNumber={setPageNumber}
            count={count}
            pageSize={PAGE_SIZE}
          />
        </>
      ) : (
        <div className={styles.message}>Şu an, yeni bir duyuru yok.</div>
      )}
    </main>
  );
}
