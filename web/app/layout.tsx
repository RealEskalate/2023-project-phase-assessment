import NavBar from '@/components/layout/NavBar'
import './globals.css'
import type { Metadata } from 'next'
import Footer from '@/components/layout/Footer'

export const metadata: Metadata = {
  title: 'Hakim Hub',
  description: 'Hakim Hub assessment',
}

export default function RootLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <html lang="en">
      <body className="max-h-screen">
        <NavBar/>
        {children}
        <Footer/>
      </body>
    </html>
  )
}



