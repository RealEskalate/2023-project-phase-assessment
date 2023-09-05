'use client';

import { useSearchQuery } from '@/redux/apiSlice';
import {BiSearchAlt} from 'react-icons/bi'
import { useState,useEffect } from 'react';
import Search from './Search';
import DoctorCard from './doctorCard';
export default function section(){
    const [keyword, setKeyword] = useState('');
    const { data, error, isLoading } = useSearchQuery({keyword: keyword, institutions: false, articles: false, start: 1, size: 12});
    useEffect(() => {
        if (data) {
        }
    }, [keyword]);
    
    return (
        <div className='text-center p-10'>
            <div
                className="w-10/12 mx-auto">
                <div className='border-2 w-full h-12 rounded-full flex justify-between items-center px-6'>
                    <input 
                    type="text" 
                    className='h-full flex-grow focus:outline-none'
                    onChange={(e) => setKeyword(e.target.value)}
                    />
                    <BiSearchAlt className=' text-3xl text-gray-400 hover:scale-105'/>
                </div>
            </div>
            <div className='grid grid-cols-4 gap-6 mt-12'>
                {data && data.data.map((doctor:any,i:number) => {
                {console.log(doctor)}
                return(
                    <a href={`/${doctor._id}`}>
                    <div className='flex flex-col items-center p-4 rounded-2xl shadow-2xl shadow-gray-200 space-y-6'>
                    <img className='w-28 h-28 rounded-full border-[5px] border-[#6C63FF]' src={doctor.photo} alt="" />
                    <h1>{doctor.fullName}</h1>
                    {doctor.speciality && 
                    <p className='bg-[#6C63FF] p-2 px-3 text-[#DDDCEF] rounded-full'>{doctor.speciality[0].name}</p>}
                    {doctor.mainInstitution && <p>{doctor.mainInstitution.institutionName}</p> }
                    </div>
                    </a>
                    )
                })}
            </div>
        </div>
    )
}