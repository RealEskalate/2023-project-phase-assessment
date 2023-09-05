import './globals.css'
import type { Metadata } from 'next'
import { Inter } from 'next/font/google'
import Header from './components/Header'
import Footer from './components/Footer'
import { Provider } from 'react-redux'
import { store } from './store/store'

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
    
    <Provider store={store}>
       <Header/>
      <body className={inter.className}>{children}</body>
      <Footer/>
    </Provider>
  )
}
