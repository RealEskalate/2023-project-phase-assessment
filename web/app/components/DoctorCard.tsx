import React from 'react'
import Image from 'next/image';
import Demo from '@/assets/Images/demo.jpg';


import { Poppins } from 'next/font/google'

const popins = Poppins({ weight: '700', subsets: ['latin'] })
const popinsLight = Poppins({ weight: '200', subsets: ['latin'] })
const popinsLightMedium = Poppins({ weight: '400', subsets: ['latin'] })

const DoctorCard = ({data}) => {
  return (
    <div className='inline-block'>
        <div className='flex flex-col gap-6 w-80 items-center justify-center shadow-lg px-10 py-6 rounded-xl mt-4 mx-4'>
            <div className='flex flex-col gap-3'>
                <div className='rounded-full flex justify-center'>
                    <Image src={data.photo} alt="profile" width={96} height={96} className='!w-24 !h-24 overflow-hidden rounded-full border-4 border-[#6C63FF]'/> 
                </div>
                <h1 className={`${popins.className} w-full flex justify-center text-lg`}>{data.fullName}</h1>
                <h1 className={`bg-[#6C63FF] ${popinsLight.className} text-sm px-2 flex justify-center py-2 rounded-full text-white`}>
                    {data.speciality[0].name}
                </h1>
            </div>
            <div>
                <p className={`text-center ${popinsLightMedium.className} text-[#686868] flex gap-3`}>
                    {data.institutionID_list.map(()=>{
                        return <span> {data.institutionID_list[0].institutionName} | </span>
                    })}
                </p>
            </div>
        </div>

    </div>
  )
}

export default DoctorCard