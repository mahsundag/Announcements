import { Inter } from "next/font/google";
import Image from "next/image";
import Link from "next/link";
import "./globals.css";
import styles from "./layout.module.css";

const inter = Inter({ subsets: ["latin"] });

export const metadata = {
  title: "Corendon Announcements",
  description: "Corendon Announcements",
};

export default function RootLayout({ children }) {
  return (
    <html lang="tr">
      <body className={inter.className}>
        <header className={styles.header}>
          <Link href="/">
            <Image
              src="/logo.png"
              alt="Corendon Logo"
              width={186}
              height={36}
            />
          </Link>
        </header>
        {children}
      </body>
    </html>
  );
}
