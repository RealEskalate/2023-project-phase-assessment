'use client'
import React from 'react'
import Home from '@/components/homePage/Home'
import { store } from "@/store/page";
import {Provider} from 'react-redux'
const page = () => {
  return (
    <div className='min-h-screen bg-white'>
      <Provider store={store}>
      <Home/>
      </Provider>
    </div>
  )
}

export default page
