'use client'

import React from 'react'
import { useGetSingleDoctorQuery } from '@/store/features/doctors/apiSlice'
import { DoctorProfile } from '@/types/doctors/models'
import Image from 'next/image'
import { BsFillTelephoneFill } from 'react-icons/bs'
import { HiMail } from 'react-icons/hi'

interface PropsInterface {
  params: {
    id: string;
  }
}

type HookResult = {
  data?: DoctorProfile;
  isLoading: boolean;
  isError: boolean;
}

const Page: React.FC<PropsInterface> = ({ params }) => {
  const { data, isLoading, isError }: HookResult = useGetSingleDoctorQuery(params.id);

  if (isLoading) {
    return <div>Is Loading...</div>
  }

  if (isError) {
    return <div>Is Error...</div>
  }

  console.log(data?.mainInstitution.institutionName)
  const defaultAbout = 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolorem accusamus voluptatum dolores at animi. Soluta, pariatur, accusantium quibusdam quasi eaque recusandae tempore voluptas hic architecto animi ipsum odio! At itaque obcaecati voluptates omnis labore. Iste dolorem assumenda mollitia nihil, unde dignissimos! Provident quos dolor, ducimus officia velit neque, veniam, odio soluta laborum in fugit illo beatae delectus quidem exercitationem modi. Eius illum similique inventore incidunt aliquam repellendus fuga, sunt odit, soluta doloremque maiores, quae est ipsa dolorum ex accusantium provident quaerat. Qui eos, temporibus nulla dolor enim corrupti dolores voluptatem nobis alias. Laudantium eaque, earum magni officiis unde itaque optio?'

  return (
    <div className='mx-16 my-10 relative font-poppins'>
      <Image
        className='rounded-2xl'
        src='/images/default-cover.jpg'
        alt='default-cover'
        width={ 1000 }
        height={ 100 }
      />
      <Image
        className='rounded-full border-2 -mt-20 shadow-lg shadow-secondary border-secondary mx-auto relative z-2'
        src={ data?.photo || '/images/test-card-image.png' }
        alt={ data?.fullName || 'default-cover' }
        width={ 150 }
        height={ 100 }
      />

      <div className='mt-20 flex flex-col space-y-9 max-w-2xl'>
        <div className='flex justify-between'>
          <div>
            <h3 className='text-xl font-bold'>{ data?.fullName }</h3>
            <span className='text-md text-gray-400'>{ data?.speciality[0].name }</span>
          </div>
          <div>
            <h5 className='text-xs text-gray-400'>Addis Ababa University</h5>
            <span className='text-sm text-gray-500'>Washington Medical Center</span>
          </div>
        </div>

        <div className='mt-10'>
          <h3 className='font-bold mb-2'>About</h3>
          <p className='text-xs'>
            { data?.summary }
          </p>
        </div>

        <div>
          <h3 className='font-bold mb-2'>Education</h3>
          <div className='flex justify-between'>
            <div>
              <h4 className='text-md'>Addis Ababa University</h4>
              <h5 className='text-xs text-gray-500'>B. Sc Medicine</h5>
            </div>
            <div className='text-gray-400 text-sm'>2003 - 2007</div>
          </div>
        </div>
        <div>
          <h3 className='font-bold mb-4'>Contact Info</h3>
          <div className='flex flex-col space-y-5'>
            <div className='flex space-x-3 items-center'>
              <BsFillTelephoneFill
                className='text-xs'
              />
              <div>
                <h4 className='text-sm font-semibold text-secondary'>Phone Number:</h4>
                {
                  data?.phoneNumbers?.map((phone) => (
                    <h5 className='text-xs text-gray-500'>{ phone }</h5>
                  ))
                }
                <h5 className='text-xs text-gray-500'>{ data?.phoneNumbers }</h5>
              </div>
            </div>

            <div className='flex space-x-3 items-center'>
              <HiMail
                className='text-xs'
              />
              <div>
                <h4 className='text-sm font-semibold text-secondary'>Email:</h4>
                {
                  data?.emails.map((email) => (
                    <h5 className='text-xs text-gray-500'>{ email }</h5>
                  ))
                }
              </div>
            </div>
          </div>
        </div>
      </div>

    </div>
  )
}

export default Page;