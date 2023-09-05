'use client'
import React from 'react'
import LoadingSpinner from '@/components/Spinner'
import { Circles } from 'react-loader-spinner'

export default function Loading() {
  return (
    <div>
      here
      <Circles
        height="80"
        width="80"
        color="#4fa94d"
        ariaLabel="circles-loading"
        wrapperStyle={{}}
        wrapperClass=""
        visible={true}
      />
    </div>
  )
}