import React from 'react'
import Image from 'next/image'
import {BsChevronDown} from 'react-icons/bs'

const NavBar = () => {
  return (
    <div className='bg-white h-20 w-full flex justify-between px-10 mb-0'>
        <div className='flex space-x-1'>
            <div>
                <Image 
                src='/logo.svg'
                alt='logo image'
                width={50}
                height={50}
                />
            </div>
            <div>
                <h1 className='text-2xl font-bold pt-4'>Hakim <span className='text-red-500'>Hub</span></h1>
            </div>
            
                

        </div>
        <div className='flex space-x-2 space-y-1 pt-3 '>
            <div>
                <Image 
                src='/profile.png'
                alt='profile image'
                width={50}
                height={50}
                />

            </div>
            <div className='text-gray-600 text-sm pt-3 flex'>
                Jonathan Alemayew 
                <div className='px-2 pt-1'>
                    <BsChevronDown  />

                </div>
                
            </div>
        </div>
      
    </div>
  )
}

export default NavBar
