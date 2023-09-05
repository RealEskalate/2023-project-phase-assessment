"use client"

import { Doctor } from '@/lib/redux/type'
import Image from 'next/image';
import React from 'react'

interface Props {
  doctor: Doctor
}

const DoctorCard: React.FC<Props> = ({ doctor }) => {

  console.log(doctor.speciality);


  return (
    <div className='flex flex-col'>
      <div className='border-2 border-primaryColor-200 rounded-full -mb-10 self-center object-cover overflow-hidden w-32 h-32'>
        <Image className='' src={doctor.photo} alt='Image' width={200} height={200} />
      </div>
      <div className='pt-14 pb-8 shadow-xl flex flex-col items-center gap-y-4 rounded-3xl	hover:shadow-2xl h-52'>
        <h1 className='font-bold'>{doctor.fullName}</h1>
        {
          doctor.speciality?.length > 0 ? <span className='text-white font-light bg-primaryColor-200 px-3 rounded-full'>{doctor.speciality[0].name}</span> : <span className='text-white font-light bg-primaryColor-200 px-3 rounded-full'>None</span>
        }

        <div className='flex items-center'>
          <p className='text-textBlack-100 font-normal'>{doctor.institutionID_list ? doctor.institutionID_list[0].institutionName : "No specialty"}</p>
        </div>

      </div>
    </div>
  )
}

export default DoctorCard