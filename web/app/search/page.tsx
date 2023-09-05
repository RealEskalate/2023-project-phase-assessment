'use client'
import React from 'react'
import SearchPage from '@/components/search/SearchPage'
import { Provider } from 'react-redux'
import { store } from '@/store/page'

const page = () => {
  return (
    <div>
        <Provider store={store}>
        <SearchPage/>
        </Provider>
    </div>
  )
}

export default page