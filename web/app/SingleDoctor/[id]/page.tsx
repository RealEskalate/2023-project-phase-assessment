'use client'
import React from 'react'
import Image from 'next/image'
import { useGetDoctorsQuery } from '@/app/api/apiSlice'
import { useParams } from 'next/navigation'

const page = () => {
    const router = useParams();
    const { id } = router;
    console.log(id);
    const {data: doctors, isLoading, isSuccess, isError, error} = useGetDoctorsQuery(id)
    console.log(isSuccess)
  return (
    <div>
    <div className='flex flex-col items-center justify-center mb-10'>
        <div className='my-20'>
            <Image 
                src='/bg-pic.png'
                width={1268}
                height={846}
                alt="picture"
                className='rounded-2xl absolute top-50 left-48 z-0'
            />
            <Image 
                src='/Ellipse 27.svg'
                width={227}
                height={227}
                alt="picture"
                className='absolute top-96 left-2/4 z-20 rounded-full'
            />
        </div>
        <div className='flex mt-96 space-x-96 w-full ml-96'>
            <div className=''>
                <div className='text-3xl font-semibold'>Dr. Fasil Tefera</div>
                <div className='text-xl font-light'>Internal Medicine</div>
            </div>
            <div className='pr-96'>
                <div className='text-base font-normal pl-16'>Addis Ababa University</div>
                <div className='text-xl font-normal'>Washington Medical Center</div>
            </div>
        </div>
        </div>
        <div className='text-lg font-bold ml-48 mb-5'>About</div>
        <div className='text-base ml-48 mr-96 pr-80 mb-20'>
            <p>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis pellentesque purus sit amet mi 
            aliquam, id dictum augue vulputate. Pellentesque porta, ligula non pulvinar sollicitudin, dolor 
            nunc molestie dui, sit amet volutpat eros nibh vitae magna. Nullam tempor, purus nec rutrum 
            varius, arcu massa scelerisque diam, nec vestibulum diam neque a massa. Mauris tempor odio in 
            ornare cursus. Maecenas in ultricies sapien. Suspendisse dolor turpis, pretium vitae lacus eget,
             condimentum aliquam diam.
            </p>
        </div>
        <div className='text-lg font-bold ml-48 mb-5'>Education</div>
        <div className='mb-20'>
            <div className='flex justify-between ml-48 mr-96 pr-80  mb-10'>
                <div>
                    <div>Addis Ababa University</div>
                    <div>B. Sc Medicine</div>
                </div>
                <div>
                    2003-2007
                </div>
            </div>
            <div className='flex justify-between ml-48 mr-96 pr-80  '>
                <div>
                    <div>Harvard University</div>
                    <div>M. Sc Internal Medicine</div>
                </div>
                <div>
                    2007-2011
                </div>
            </div>
        </div>
        <div className='text-lg font-bold ml-48 mb-5'>Contact info</div>
        <div className='mb-14'>
            <div className='flex ml-48 gap-3 mb-2'>
                <svg width="16" height="17" viewBox="0 0 16 17" fill="none" xmlns="http://www.w3.org/2000/svg" className='mt-2'>
                    <path d="M3.1675 7.44125C4.4275 9.9175 6.4575 11.9387 8.93375 13.2075L10.8587 11.2825C11.095 11.0463 11.445 10.9675 11.7513 11.0725C12.7312 11.3962 13.79 11.5712 14.875 11.5712C15.3562 11.5712 15.75 11.965 15.75 12.4462V15.5C15.75 15.9812 15.3562 16.375 14.875 16.375C6.65875 16.375 0 9.71625 0 1.5C0 1.01875 0.39375 0.625 0.875 0.625H3.9375C4.41875 0.625 4.8125 1.01875 4.8125 1.5C4.8125 2.59375 4.9875 3.64375 5.31125 4.62375C5.4075 4.93 5.3375 5.27125 5.0925 5.51625L3.1675 7.44125Z" fill="#484848"/>
                </svg>
                <div className='text-purple text-base font-bold'>Phone number</div>
            </div>
            <div className='text-sm ml-56'>+25111763498</div>
        </div>
        <div>
            <div className='flex ml-48 gap-3 mb-2'>
            <svg width="18" height="15" viewBox="0 0 18 15" fill="none" xmlns="http://www.w3.org/2000/svg" className='mt-2'>
                <path d="M15.75 0.5H1.75C0.7875 0.5 0.00874999 1.2875 0.00874999 2.25L0 12.75C0 13.7125 0.7875 14.5 1.75 14.5H15.75C16.7125 14.5 17.5 13.7125 17.5 12.75V2.25C17.5 1.2875 16.7125 0.5 15.75 0.5ZM15.75 4L8.75 8.375L1.75 4V2.25L8.75 6.625L15.75 2.25V4Z" fill="#484848"/>
            </svg>
                <div className='text-purple text-base font-bold'>Email</div>
            </div>
            <div className='text-sm ml-56'>fasiltefera@stpaul.com</div>
        </div>
       <div className='mb-96'></div>
    </div>
  )
}

export default page
