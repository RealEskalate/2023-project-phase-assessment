"use client"

import React from 'react'
import Image from 'next/image'
import { useParams } from "next/navigation";
import { useGetHakimDetailsQuery } from '@/app/Redux/hakimApi';
import EducationCard from '@/components/EducationCard';
import ContactCard from '@/components/ContactCard';



const hakimDetail = () => {
    const params = useParams();
    const hakimId = params.hakimId as string;
    // console.log(hakimId)

    const { data, isLoading, error } = useGetHakimDetailsQuery(hakimId);
    
    

  return (
    <div className='relative px-20 bg-white h-full'> 
    <div>
        <Image
            src="/bg.png"
            alt="background picture"
            layout="responsive"
            width={800}
            height={300}
            objectFit="cover"
            className='rounded-3xl'
            />
    </div>
    <div className='absolute top-36 h-52 w-52 left-1/2 '>
        <Image
            src={data?.photo}
            alt="background picture"
            width={30}
            height={30}
            objectFit="cover"
            className='rounded-full border-2 border-purple-800 h-52 w-52'
            />

    </div >
    <div className='w-2/3 px-10'>
        <div className='flex w-2/3 left-0 justify-between pt-20'>
        <div >
        <div className='text-xl font-bold'>{data?.fullName}</div>
        <div className='text-gray-600 text-lg font-semibold'>Internal Medicine</div>

    </div>
    <div>
        <div className='text-sm right-0 text-gray-500'>Addis Abaab University</div>
        <div className='text-lg text-gray-600'>{data?.institutionName}</div>
        
        
    </div>

    </div>
    {/* about */}
    <div className='py-2'>
        <h5 className='font-semibold py-2'>About</h5>
        <p className='text-sm text-gray-600'>
            This is about section. This is about section. This is about section. This is about section. 
            This is about section. This is about section. This is about section. This is about section. 
            This is about section. This is about section. This is about section. This is about section. 
            This is about section. This is about section. This is about section. This is about section. 

        </p>
    </div>

    {/* education */}
    <div>
        <h5 className='font-bold px-2'>Education</h5>
        <EducationCard />
        <ContactCard />

    </div>

    </div>
    
    
        

    </div>
  )
}

export default hakimDetail