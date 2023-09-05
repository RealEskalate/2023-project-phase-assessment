'use client'

import React from 'react';
import { useParams } from 'next/navigation';
import { useFetchDoctorQuery } from '@/store/features/doctors/doctors-api';
import Loading from '@/components/common/Loading';
import Error from '@/components/common/Error';
import { FiPhone, FiMail } from 'react-icons/fi'; // Import React Icons

const DoctorDetailPage = () => {
  const params = useParams();
  const doctorId = params.id;
  const { data: doctor, error, isLoading } = useFetchDoctorQuery(doctorId as string);

  if (isLoading) {
    return <Loading />;
  }

  if (error) {
    return <Error message='Oops, Error Occurred' />;
  }

  return (
    <div className='mb-8'>
      <div className='flex flex-col py-16 px-24 relative'>
        <div className='w-full'>
          <img
            src='/navbar/background.png'
            alt='Background'
            className='w-full h-auto object-cover'
          />
        </div>
        <div className='absolute bottom-0 left-1/2 transform -translate-x-1/2'>
          <div className='rounded-full overflow-hidden bg-gray-200 w-48 h-48'>
            <img
              src={doctor?.photo}
              alt={doctor?.fullName}
              className='object-cover'
            />
          </div>
        </div>
      </div>
      <div>
          <div className='w-1/2'>
            <div className='flex justify-between items-center px-32 '>
              <div>
                <p className='font-bold'>{doctor?.fullName}</p>
                <p className='font-light'>{doctor?.speciality.map((speciality) => speciality.name).join(',')}</p>
              </div>
              <div>
                <p className='font-light'>Addis Ababa</p>
                <p className='font-light' >{doctor?.institutionID_list.map((insitution) => insitution.lang.am.institutionName).join(' | ')}</p>
              </div>
            </div>
            <div className='px-32 mt-8'>
              <h1 className='font-bold'>About</h1>
              <p className='font-light flex-wrap'>
                Lorem ipsum dolor sit amet consectetur adipisicing elit. Harum ex odio architecto, quo nihil, culpa, beatae ea explicabo molestiae doloribus voluptates quia. Doloremque distinctio itaque labore quisquam quidem facere voluptatem.
              </p>
            </div>
            <div className='my-8 px-32 flex flex-col gap-4'>
              <h1 className='font-bold'>Education</h1>
              <div className='flex justify-between'>
                <div className=''>
                  <p className='font-semibold'>Addis Ababa University</p>
                  <p className='font-light'>BSc Medicine</p>
                </div>
                <div className='font-light'>
                  2003 - 2007
                </div>
              </div>
              <div className='flex justify-between'>
                <div className=''>
                  <p className='font-semibold'>Harvard University</p>
                  <p className='font-light'>BSc Medicine</p>
                </div>
                <div className='font-light'>
                  2008 - 2018
                </div>
              </div>
            </div>
            <div className= ' px-32 flex flex-col gap-4 '>
              <h1 className='font-bold'>Contact Info</h1>
              <div>
                <div className='flex gap-2'>
                <FiPhone className='text-primary' /> 
                <p>Phone number</p>
                </div>
                <p className='pl-2 text-sm font-light'>0920520751</p>
              </div>
              <div>
                <div className='flex gap-2'>
                <FiMail className='text-primary' /> 
                <p>Email</p>
                </div>
                <p className='pl-2 text-sm font-light'>yohannes@a2sv.org</p>
              </div>
            </div>
          </div>
          <div></div>
        </div>
      </div>
    
  );
};

export default DoctorDetailPage;
