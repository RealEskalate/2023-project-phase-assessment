'use client'
import React from 'react'
import Image from 'next/image'
import { useSearchParams } from 'next/navigation'
import { useSearchDoctorsQuery } from '@/store/apiSlice'


const SearchPage = () => {
    const search = useSearchParams()
    const searchQuery = search?search.get('q'):null;
    const encodedSearchQuery = encodeURI(searchQuery || "")

    const{data:doctors, isSuccess} = useSearchDoctorsQuery(encodedSearchQuery)
    return (
        <div className="flex flex-col items-center gap-12 text-black">
            <div className="grid grid-cols-4 gap-4 pb-4">
            {
                doctors?.data.map((doctor:any)=>{
                    return(
                    <div key={doctor._id} className="flex flex-col items-center gap-2 bg-white rounded-md shadow-lg p-8">
                        <Image src={doctor.photo} className="rounded-full" border-blue-500 height={98} width={90} alt="`${doctor.fullName}`"/>
                        <p className="font-poppins font-normal text-xl text-black">{doctor.fullName}</p>
                        <div className="text-white text-center bg-sub-primary rounded-md w-32">
                            {doctor.speciality?.map((special:any)=>{
                            return <p key={special._id}>{special.name}</p>
                        })}
                        </div>
                        <div>
                            {doctor.institutionID_list?.map((item:any)=>{
                                return <p>{item.institutionName}</p>
                            })}
                        </div>
                    </div>)
                })
            }
            </div>
            
        </div>
      )
}

export default SearchPage