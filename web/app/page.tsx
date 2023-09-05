"use client"
import { useGetDoctorByIdQuery, useGetDoctorsQuery, useGetDoctorsWithPaginationQuery } from '@/lib/redux/features/doctorsApi'
import { Doctor } from '@/lib/redux/type'
import Image from 'next/image'
import DoctorCard from './components/DoctorCard'
import Link from 'next/link'
import { useState } from 'react'

export default function Home() {
  const [keyword, setKeyword] = useState("")
  const [from, setFrom] = useState(1)

  const { data: doctors, isLoading, error, isSuccess } = useGetDoctorsWithPaginationQuery({ keyword: keyword, from: from })

  const totalAmount = Math.ceil(doctors?.totalCount/8);
  const pagination = [];
  
  for (let i = 1; i <= totalAmount; i++) {
    pagination.push(i);
  }

  if (isLoading) {
    return <div>Loading</div>
  } else if (error) {
    return <div>Error</div>
  }

  console.log(doctors);

  return (
    <main className='px-16 flex flex-col gap-10 mt-10 mb-10'>
      <form className='self-center flex relative w-9/12'>
        <input
          className='border-2 rounded-full px-3 py-1 w-full'
          name='search'
          type="text"
          onChange={(e) => setKeyword(e.target.value)}
          placeholder='Search'
        />

        <label htmlFor="search"><svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="absolute -ml-8 mt-1 w-6 h-6 text-gray-400">
          <path strokeLinecap="round" strokeLinejoin="round" d="M21 21l-5.197-5.197m0 0A7.5 7.5 0 105.196 5.196a7.5 7.5 0 0010.607 10.607z" />
        </svg>
        </label>
      </form>
      <div className='grid grid-cols-4 gap-x-5 gap-y-11'>
        {doctors.data.length > 0 ? (
          doctors.data.map((doctor: Doctor) => <Link href={`/doctor/${doctor._id}`} className='' key={doctor._id} ><DoctorCard doctor={doctor} /></Link>)
        ) : (
          <h1>No data</h1>
        )}
      </div>
      <div className='self-center'>
        <button className=' text-primaryColor-200 py-3 px-4 rounded-md' onClick={() => setFrom(from - 1)} ><svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="w-6 h-6">
          <path strokeLinecap="round" strokeLinejoin="round" d="M15.75 19.5L8.25 12l7.5-7.5" />
        </svg>
        </button>
        {
          pagination?.map(page => {
            return page === from ? (
              <button className='mx-2 text-white bg-primaryColor-200 border-2 border-primaryColor-200 hover:bg-primaryColor-100 py-3 px-4 rounded-md' >{page}</button>
              ) : (
              <button onClick={() => setFrom(page)} className='mx-2 text-black bg-white border-2  hover:bg-primaryColor-200 py-3 px-4 rounded-md' >{page}</button>
            )
          })
        }
        <button className=' text-primaryColor-200 py-3 px-4 rounded-md' onClick={() => setFrom(from + 1)} ><svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="w-6 h-6">
          <path strokeLinecap="round" strokeLinejoin="round" d="M8.25 4.5l7.5 7.5-7.5 7.5" />
        </svg>
        </button>
      </div>
    </main>
  )
}
