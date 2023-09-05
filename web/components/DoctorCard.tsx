'use client'

import React from 'react';
import { DoctorProfile } from '@/types/doctors/models';
import Image from 'next/image'
import Link from 'next/link'

interface PropsInterface {
  data: DoctorProfile;
}

const DoctorCard: React.FC<PropsInterface> = ({ data }) => {
  const fullName = data.fullName;
  const mainInstitution = data.mainInstitution.institutionName;
  const speciality = data.speciality[0].name;

  return (
    <div className='shadow-lg shadow-gray-200 flex flex-col justify-evenly items-center mt-10 px-10 pb-3 h-48 w-full'>
      <Image
        className='border-2 -mt-10 rounded-full border-secondary'
        src={ data.photo }
        alt={ data.fullName }
        width={ 100 }
        height={ 100 }
      />
      <div className='font-semibold text-md text-center'>
        <Link href={ `/doctor/${ data._id }` }>{ fullName }</Link>
      </div>
      <div className='bg-secondary text-white text-xs px-2 py-1 rounded-full text-center'>{ speciality }</div>
      <div className='text-xs text-gray-400 text-center mt-1'>{ mainInstitution }</div>
    </div>
  )
}

export default DoctorCard;