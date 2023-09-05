import NavBar from "@/components/common/NavBar";
import "./globals.css";
import type { Metadata } from "next";
import { Inter } from "next/font/google";
import ReduxProvider from "@/utils/redux/ReduxProvider";
import Footer from "@/components/common/Footer";

const inter = Inter({ subsets: ["latin"] });

export const metadata: Metadata = {
  title: "HakimHub",
  description: "Web assessment for Africa to Silicon Valley",
};

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="en">
      <body className="min-h-screen font-poppins">
        <ReduxProvider>
          <NavBar />
          <div className="min-h-[55vh]">{children}</div>
          <Footer />
        </ReduxProvider>
      </body>
    </html>
  );
}
