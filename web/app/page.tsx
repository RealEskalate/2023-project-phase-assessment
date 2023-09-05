"use client"

import Image from 'next/image'
import Search from '@/components/Search'
import HakimCard from '@/components/HakimCard'
import HakimList from '@/components/HakimList'
import PaginationButtons from '@/components/PaginationButtons'
export default function Home() {
  return (
    <div className='pt-8 bg-white'>
      <Search />
      <HakimList />
      <HakimCard key="1" name="ruth" specialization = "hello"/>
      <PaginationButtons />
      
    </div>
  )
}
