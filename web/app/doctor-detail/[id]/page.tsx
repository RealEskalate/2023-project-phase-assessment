'use client'
import React, { useEffect, useState } from 'react'
import Image from 'next/image';
import SerarchBar from '../../components/SerarchBar'
import profileBackground from '@/assets/Images/ProfileCover.png';
import DemoImg from '@/assets/Images/demo.jpg';
import {HiPhone} from 'react-icons/hi';
import { IoMdMail } from 'react-icons/io';
import { Poppins } from 'next/font/google'
import { useGetDetailDocQuery } from '../../lib/redux/slice/doctors-slice';
import { DotWave } from '@uiball/loaders'




const popins = Poppins({ weight: '700', subsets: ['latin'] })
const popinsLight = Poppins({ weight: '200', subsets: ['latin'] })
const popinsLightMedium = Poppins({ weight: '400', subsets: ['latin'] })



const EducationSection = ({uni, feild})=>{
    return(
        <div className='flex justify-between items-center'>
            <div className='flex flex-col gap-3'>
                <h1 className={`${popins.className} text-2xl`}>{uni}</h1>
                <p className={`${popinsLightMedium.className}`}>{feild}</p>
            </div>  
            <p className={`${popinsLightMedium.className}`}>2003- 2007</p>
        </div>
    )
}
const DoctorDetail = ({params}) => {
    const id = params.id
    const {data, isLoading} = useGetDetailDocQuery(id);
    console.log(data)

    if(isLoading){
        return ( 
        <div className='w-full flex justify-center items-center'>
            <DotWave 
                size={150}
                speed={1} 
                color="#7879F1"
            />
        </div>)
    }
    else{
        return (
            <div>
                <div className='h-72 mx-10 md:mx-20 rounded-3xl flex mt-20 items-end justify-center' style={{backgroundImage: `url(${profileBackground.src})`, backgroundRepeat: 'no-repeat', backgroundSize: "cover"}}>
                    <Image src={data.photo} width={208} height={208} alt='doctor profile' className='!h-52 !w-52 rounded-full mb-[-100px] shadow-2xl shadow-[#6C63FF]/60'/>
                </div>
                <div className='w-7/12 mt-32 mx-20'>
                    <div className='flex justify-between'>
                        <div className='flex flex-col gap-3'>
                            <h1 className={`${popins.className} text-2xl`}>{data.fullName}</h1>
                            <p className={`${popinsLightMedium.className}`}>{data.speciality[0].name}</p>
                        </div>
                        <div className='flex flex-col gap-3 text-right'>
                            <p className={`${popinsLightMedium.className}`}>{data.education ? data.education : "Addis Ababa University"}</p>
                            <p className={`${popinsLightMedium.className}`}>{data.institutionID_list[0].institutionName}</p>
                        </div>
                    </div>
        
                    <div className='mt-20 flex flex-col gap-4'>
                        <h1 className={`${popins.className} text-2xl`}>About</h1>
                        <p className='w-'>Lorem ipsum dolor sit amet consectetur adipisicing elit. Ipsum in magnam quidem, distinctio voluptatum aspernatur iure laboriosam dignissimos non obcaecati quis! Et, nulla blanditiis cumque minima dignissimos minus voluptas. Perferendis?</p>
                    </div>
        
                    <div className='mt-20 flex flex-col gap-4'>
                        <h1 className={`${popins.className} text-2xl`}>Education</h1>
                        <EducationSection feild={"medicine"} uni={"Addis Ababa uni"} />
                    </div>
        
                    <div className='flex flex-col gap-3 mt-20'>
                        <h1 className={`${popins.className} text-2xl`}> Contact Info</h1>
                        <div className='flex flex-col gap-2'>
                            <div className='flex gap-3'>
                                <HiPhone className="text-xl mt-2"/>
                                <div className='flex flex-col gap-4'>
                                    <h1 className={`${popins.className} text-2xl text-[#7879F1]`}>Phone Number:</h1>
                                    <p className={`${popinsLightMedium.className}`}>+251987654321</p>
                                </div>
                            </div>
        
                            <div className='flex gap-3 mt-10'>
                                <IoMdMail className="text-xl mt-2" />
                                <div className='flex flex-col gap-4'>
                                    <h1 className={`${popins.className} text-2xl text-[#7879F1]`}>Email:</h1>
                                    <p className={`${popinsLightMedium.className}`}>{data.fullName}@gmail.com</p>
                                </div>
                            </div>
        
                        </div>
                    </div>
        
                </div>
            </div>
          )
    }
}

export default DoctorDetail