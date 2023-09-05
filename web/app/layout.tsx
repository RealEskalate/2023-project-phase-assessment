import Header from "@/components/common/Header";
import "./globals.css";
import type { Metadata } from "next";
import Footer from "@/components/common/Footer";
import ReduxProvider from "@/components/common/ReduxProvider";

export const metadata: Metadata = {
  title: "Create Next App",
  description: "Generated by create next app",
};

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="en">
      <body className="font-Poppins">
        <ReduxProvider>
          <Header />
          {children}
          <Footer />
        </ReduxProvider>
      </body>
    </html>
  );
}
