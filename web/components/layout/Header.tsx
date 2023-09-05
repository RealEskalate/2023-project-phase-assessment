import React from 'react'
import Image from 'next/image'

import Logo from './Logo'
import profile from '@/public/images/profile.png'

export default function Header() {
  return (
    <header className='flex justify-between items-center font-poppins px-16 mt-3'> 
      <div className='flex flex-row justify-center items-center'>
        <Logo />
        <div className='text-xl pt-3 font-bold'>Hakim<span className='text-orange-500'>Hub</span></div>
      </div>
      <div className='flex flex-row items-center justify-center space-x-2'>
        <Image
          src={ profile }
          width={ 50 }
          height={ 50 }
          alt='profile'
        />
        {/* Work on the down arrow besides the name of the person */}
        <div className='text-sm'>Jonathan Alemayehu<span className='transform rotate-90 text-md'>&gt;</span></div>
      </div>
    </header>
  )
}
