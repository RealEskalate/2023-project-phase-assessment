import React from 'react'
import Image from 'next/image';
import SeachIcon from '@/assets/Images/SearchIcon.png';

import { Poppins } from 'next/font/google'

const popins = Poppins({ weight: '700', subsets: ['latin'] })
const popinsLight = Poppins({ weight: '400', subsets: ['latin'] })

const SerarchBar = ({search, setSearch}) => {
  const updateString = (e)=>{
    console.log(e.target.value)
    // setSearch(e.target.value)
  }
  return (
    <div className='flex w-full justify-center mt-20'>
      <input onChange={updateString} value={search} className={`${popinsLight.className}  text-[#DCD0D0]/50 rounded-full w-2/3 md:w-1/2 border-2 border-gray-200 outline-none py-3 px-8 pr-14 mb-10`} placeholder='Name'></input>
      <div className='w-10 h-10 flex items-center'>
        <Image src={SeachIcon} alt="search Icon" className='w-6 ml-[-50px] mt-2'/>
      </div>
    </div>
  )
}

export default SerarchBar