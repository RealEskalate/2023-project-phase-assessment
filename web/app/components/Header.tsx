"use client"
import Image from 'next/image'
import React from 'react'
import logo from '@/assets/images/Frame.svg'
import user from '@/assets/images/Ellipse 26.svg'
import downIcon from '@/assets/images/Mask.svg'
import Link from 'next/link'

const Header = () => {
  return (
    <div className='px-16 flex justify-between mt-4'>
      <Link href="/" className='flex items-center'>
        <Image src={logo} alt='HakimHub' />
        <span className='text-textBlack-400 font-bold text-2xl'>Hakim</span><span className='text-textBlack-200 font-bold text-2xl'>Hub</span>
      </Link>
      <div className='flex items-center gap-x-4'>
        <Image src={user} alt='User' />
        <div className='flex gap-x-1.5'>
          <span className='border-2'>Jonathan Alemayehu</span>
          <Image  src={downIcon} alt='User' />
        </div>
      </div>
    </div>
  )
}

export default Header