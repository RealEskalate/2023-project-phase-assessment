import './globals.css'
import type { Metadata } from 'next'
import { Inter } from 'next/font/google'
import ReduxProvider from "@/components/provider/provider";
import NavBar from "@/components/commons/NavBar";
import Footer from "@/components/commons/Footer";
import {Provider} from "react-redux";
import {store} from "@/store";

const inter = Inter({ subsets: ['latin'] })

export const metadata: Metadata = {
  title: 'Create Next App',
  description: 'Generated by create next app',
}

export default function RootLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <html lang="en">

        <body className="bg-white">
        <ReduxProvider>
            <NavBar />
            <main className="p-20 md:p-10">
                {children}
            </main>
            <Footer/>
        </ReduxProvider>

        </body>


    </html>
  )
}
