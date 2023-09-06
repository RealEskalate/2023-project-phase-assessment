"use client";
import React from 'react'
import { Provider } from "react-redux";
import "./globals.css";
import type { Metadata } from "next";
import{ store } from "@/store";
import Footer from "@/components/footer/Footer";
import Header from "@/components/header/Header";

import { Inter,Lato, Nunito, Poppins  } from 'next/font/google'

const inter = Inter({ subsets: ['latin'] })

const lato = Lato({
  subsets: ['latin'], variable: '--font-lato', weight: ['100','300','400','700','900']
})

const nunito = Nunito({
  subsets: ['latin'], variable: '--font-nunito'
})

const poppins = Poppins({
  subsets: ['latin'], variable: '--font-poppins', weight: ['100','300','400','700','900']
})


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
      <html lang="en" className={`h-screen ${poppins.className} ${nunito.className} ${lato.className}`}>
        <body>
          <Header/>
          {children}
          <Footer />
        </body>
      </html>
    </Provider>
  );
}
