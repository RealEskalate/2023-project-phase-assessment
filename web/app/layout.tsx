"use client";
import React from 'react'
import { Provider } from "react-redux";
import "./globals.css";
import type { Metadata } from "next";
import{ store } from "@/store";
import Footer from "@/components/footer/Footer";
import Header from "@/components/header/Header";

export const metadata: Metadata = {
  title: "HakimHub",
  description: "HakimHub HomePage",
};

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <Provider store={store}>
      <html lang="en">
        <body>
          <Header/>
          {children}
          <Footer />
        </body>
      </html>
    </Provider>
  );
}
