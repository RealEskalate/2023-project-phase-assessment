'use client'

import React, { useEffect, useState } from 'react'
import Image from 'next/image'
import { CiSearch } from 'react-icons/ci'

import DoctorCard from '@/components/DoctorCard'
import { DoctorProfile } from '@/types/doctors/models'
import { useGetAllDoctorsQuery, useSearchDoctorsQuery } from '@/store/features/doctors/apiSlice'
import { ApiResponse } from '@/types/doctors/apiType'

type HookResult = {
  data?: ApiResponse;
  isLoading: boolean;
  isError: boolean;
};

export default function Home() {
  const { data, isLoading, isError }: HookResult = useGetAllDoctorsQuery();
  const [search, getSearch] = useState('');
  const [doctors, setDoctors] = useState<DoctorProfile[]>([]);
  const { data: searchData, isLoading: searchLoading, isError: searchError } = useSearchDoctorsQuery(search);

  if (isError) {
    return (
      <div>Is Error...</div>
    )
  }
  const allDoctors: DoctorProfile[] | undefined = data?.data;

  const handleSearch = () => {
    if (search.length > 0) {
      setDoctors(searchData?.data || []);
    } else {
      setDoctors(allDoctors || []);
    }
  }
  
  useEffect(() => {
    setDoctors(allDoctors || []);
  }, [allDoctors]);

  return (
    <main className='font-poppins'>
      <div className='flex flex-row items-center justify-between rounded-full border max-w-3xl mx-auto px-6 py-2 mt-4 mb-10'>
        <input
          type="text"
          className='w-full outline-none bg-transparent text-sm'
          placeholder='Name'
          value={ search }
          onChange={ (e) => getSearch(e.target.value) }
        />
        <CiSearch
          onClick={ () => handleSearch() }
          className='text-gray-400 text-2xl cursor-pointer'
        />
      </div>
      <div className='grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 place-items-start my-3 gap-3 px-10'>
        {
          doctors.map((doctor) => ( <DoctorCard key={ doctor._id } data={ doctor } />  ))
        }
      </div>
    </main>
  )
}
