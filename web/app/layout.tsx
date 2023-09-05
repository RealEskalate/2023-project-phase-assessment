'use client'
import './globals.css'
import type { Metadata } from 'next'
import Nav from '@/components/Nav'
import Footer from '@/components/Footer'
import { ApiProvider } from '@reduxjs/toolkit/dist/query/react'
import { Provider } from 'react-redux'
import { apiSlice } from './api/apiSlice'
import { store } from './store'

export const metadata: Metadata = {
  title: 'HakimHub',
  description: 'HakimHub',
}

export default function RootLayout({ children, }: { children: React.ReactNode }) {
  return (
    <main>
      {/* <Provider store={store}> */}
        <Provider store={store}>
          <Nav/>
          {children}
          <Footer/>
        </Provider>
      {/* </Provider> */}
    </main>
  )
}
