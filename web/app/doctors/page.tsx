"use client"
import Link from 'next/link'
import {useState} from 'react'
import { useGetDoctorsQuery } from '@/store/features/doctors/doctors-api'
import DoctorCard from '@/components/doctors-page/DoctorCard'
import SearchBar from '@/components/header/SearchBar'



const DoctorsPage: React.FC = () => {

   const {data: doctors, error, isLoading} = useGetDoctorsQuery()

//    const {data: doctors, error, isLoading} = useFilterDoctorsQuery()

   const [search, seatSearch] = useState('')

    if (isLoading) {
        return <div>Loading...</div>
    }
    console.log(doctors)
    return (
        <div className='w-11/12 mx-auto mt-20 flex flex-col gap-10'>
            <div className='flex justify-center items-center my-5'>
            <SearchBar search={search} setSearch={seatSearch} />
            </div>
            <div className='w-full grid grid-cols-4 gap-5'>
                {
                    doctors.data.map((doctor, index) => {
                        return (<Link prefetch href={`/doctors/${doctor._id}` }>
                            <DoctorCard key={index} doctor={doctor} />
                        </Link>)
                    })
                }
            </div>

        </div>
    )
}

export default DoctorsPage