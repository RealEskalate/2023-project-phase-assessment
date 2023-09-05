import React from 'react'
import {AiOutlineArrowDown} from 'react-icons/ai'


const NavBar = () => {
  return (
    <header className='flex justify-between px-12 mt-6 font-poppins'>
      <img 
        src='/images/logo.png' 
        alt='Hakimhub logo'
      />

      <div className='flex items-center gap-2 mr-4'>
        <img 
          src="/images/avatar.png" 
          alt="Avatar"
          />
        <p>Jonathan Alemayehu</p>
        <AiOutlineArrowDown />
      </div>

      
    </header>
  )
}

export default NavBar