import React from 'react'
import Logo from '@/assets/Images/Logo.png';
import Image from 'next/image';
import ProfileImage from '@/assets/Images/Profile.png';
import ArrowDown from '@/assets/Images/arrow-ios-down.png';
import Link from 'next/link';

import { Poppins } from 'next/font/google'

const popins = Poppins({ weight: '700', subsets: ['latin'] })
const popinsLight = Poppins({ weight: '400', subsets: ['latin'] })
const Header = () => {
  return (
    <div className='flex mx-4 md:mx-20 justify-between pt-6'>
      <Link href="/">
        <div className='flex gap-3 items-center text-3xl font-bold'>
            <Image src={Logo} alt="logo" />
            <h1 className={`${popins.className} mt-4 text-[#424242]`}>Hakim<span className='text-[#FF7272]'>Hub</span></h1>
        </div>
      </Link>
        <div className='flex gap-2 items-center'>
            <Image src={ProfileImage} alt="profile"/>
            <h1 className={`${popinsLight.className} hidden md:block text-[#5A5555] text-lg`}>Jonathan Alemayehu</h1>
            <Image src={ArrowDown} alt='arrowdown' />
        </div>
    </div>
  )
}

export default Header