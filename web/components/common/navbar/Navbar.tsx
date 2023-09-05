import React from 'react';
import Image from 'next/image';

const Navbar = () => {
  return (
    <div>
      <div className="flex gap-4 sm:gap-0 items-center justify-between py-3 px-4 md:px-10">
        <div >
          <Image src="/navbar/logo.png" alt="logo"  width={234} height={59} />
        </div>
        <div className=" flex items-center space-x-1 pt-1 md:space-x-3 md:pt-3">
          <Image src={'/navbar/profile.png'} alt='logo' width={68} height={68} />
          <p className='hidden sm:flex'>Jonathan Alemayehu</p>
          <div className='hidden sm:flex'>
            <svg
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              stroke="currentColor"
              className="h-4 w-4 text-black transform rotate-90"
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                strokeWidth="2"
                d="M9 5l7 7-7 7"
              ></path>
            </svg>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Navbar;
