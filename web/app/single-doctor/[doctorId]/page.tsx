'use client'

import React from 'react';
import { useGetSingleDoctorQuery } from '@/store/features/doctor/doctor-api';

const doctor = {
  image: 'https://res.cloudinary.com/hakimhub/image/upload/v1656314302/POP_DATA_DOC/Addis_Cardiac_Hospital_0.jpg',
  name: 'Tesfaye Bekele',
  speciality: 'Orthopedic',
  uni: 'Addis Ababa University',
  hosp: 'Yekatit 12',
  uni_1: 'Addis Ababa University',
  uni_2: 'Howard medical school',
  date_1: '2003-2007',
  date_2: '2007-2011',
  tel: '0900026618',
  email: 'admas@gmail.com'
}

interface props {
  params: {
    id: string;
  }
}

const SingleDoctorPage: React.FC<props> = ( { params }) => {
  const { data, isLoading, isError } = useGetSingleDoctorQuery(params.id);

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError || !data) {
    return <div>Error fetching data.</div>;
  }

  const doctor = data; 

  return (
  <section>
      <div className='w-100 mx-10 mt-12'>
        <img src="/images/heart-machine.png" alt="Stethescope" />
      </div>
      <img className='mx-auto rounded-full w-40 h-40 -mt-20' src={doctor.photo} alt='doctor photo' />

      <div className='w-1/2 mx-16 mt-10 border border-red-500'>

        <div className='flex flex-col justify-between'>
          <div className='flex mb-48 justify-between'>
            <div>
              <h2 className='font-bold text-2xl'>{doctor.fullName}</h2>
              <p className='text-gray-400'>{doctor.speciality[0].name}</p>
            </div>
            <div className='text-gray-400 self-end'>
              <p>{doctor.uni}</p>
              <p>{doctor.hosp}</p>
            </div>
          </div>

          <div className='flex flex-col'>
            <div className='flex flex-col'>
              <div className='flex justify-between'>
                <p className='font-semibold'>{doctor.uni_1}</p>
                <p>{doctor.date_1}</p>
              </div>
              <div className='flex justify-between'>
                <p className='font-semibold'>{doctor.uni_2}</p>
                <p>{doctor.date_2}</p>
              </div>
            </div>
          </div>
          
          <div className='mt-4'>
            <div>
              <p className='font-semibold my-8'>Contact Info</p>
              <p className='mb-2 text-sub-primary font-semibold'>Phone Number</p>
              <p>{doctor.tel}</p>
            </div>
            <div>
              <p className='mt-2 mb-2 text-sub-primary font-semibold'>Email</p>
              <p>{doctor.email}</p>
            </div>
          </div>
        </div>
      </div>

  </section>
  );
}

export default SingleDoctorPage;
