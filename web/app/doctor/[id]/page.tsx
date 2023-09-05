"use client"
import { useGetDoctorByIdQuery } from '@/lib/redux/features/doctorsApi'
import Image from 'next/image'
import React from 'react'
import backgroundImage from '@/assets/images/manik-roy-u7GtZ0yVijw-unsplash 1.png'

const doctor = ({ params }: { params: { id: string } }) => {

  const _id = params.id
  const { data: doctor, isLoading, error, isSuccess } = useGetDoctorByIdQuery({ _id })

  if (isLoading) {
    return <div>Loading</div>
  } else if (error) {
    return <div>Error</div>
  }

  console.log(doctor.emails);
  

  return (
    <div className='mt-10'>
      <div className='flex flex-col items-center mb-10'>
        <Image className='rounded-xl' src={backgroundImage} alt='Background Image' />
        <Image className='border-4 border-primaryColor-200 rounded-full -mt-28' src={doctor.photo} width={227} height={227} alt='Profile Pic' />
      </div>
      <div className='w-8/12'>
        <div className='flex justify-between'>
          <div>
            <h1 className='text-black text-2xl font-semibold'>{doctor.fullName}</h1>
            {
              doctor.speciality?.length > 0 ? <h2 className='text-textBlack-300 text-base font-light'>{doctor.speciality[0].name}</h2> : <h2 className=''>None</h2>
            }
          </div>
          <div>
            {
              doctor.education?.length > 0 ? (
                <h2 className='text-textBlack-300 font-normal'>{doctor.education[0]}</h2>
              ) : (
                <h2>No info</h2>
              )
            }

            <h2 className='text-textBlack-300 font-normal'>{doctor.institutionID_list ? doctor.institutionID_list[0].institutionName : "No specialty"}</h2>

          </div>
        </div>
        <div className='mt-24'>
          <h1 className='font-bold mb-3'>About</h1>
          <p className='text-justify text-base'>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis pellentesque purus sit amet mi aliquam, id dictum augue vulputate. Pellentesque porta, ligula non pulvinar sollicitudin, dolor nunc molestie dui, sit amet volutpat eros nibh vitae magna. Nullam tempor, purus nec rutrum varius, arcu massa scelerisque diam, nec vestibulum diam neque a massa. Mauris tempor odio in ornare cursus. Maecenas in ultricies sapien. Suspendisse dolor turpis, pretium vitae lacus eget, condimentum aliquam diam.
          </p>
        </div>
        <div className='mt-24'>
          <h1 className='font-bold mb-3'>Education</h1>
          <p>No education</p>
        </div>
        <div className='mt-10'>
          <h1 className='font-bold mb-3'>Contact Info</h1>
          <p className='flex gap-x-3'><svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="w-6 h-6">
            <path strokeLinecap="round" strokeLinejoin="round" d="M21.75 6.75v10.5a2.25 2.25 0 01-2.25 2.25h-15a2.25 2.25 0 01-2.25-2.25V6.75m19.5 0A2.25 2.25 0 0019.5 4.5h-15a2.25 2.25 0 00-2.25 2.25m19.5 0v.243a2.25 2.25 0 01-1.07 1.916l-7.5 4.615a2.25 2.25 0 01-2.36 0L3.32 8.91a2.25 2.25 0 01-1.07-1.916V6.75" />
          </svg>
            <span className='text-primaryColor-100 font-bold'>Email:</span></p>
          <p className='ml-4'>{doctor.emails.length>0? doctor.emails[0]: "     No email"}</p>
        </div>
      </div>
    </div>
  )
}

export default doctor