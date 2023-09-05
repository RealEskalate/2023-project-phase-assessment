import React from 'react'
import {BsFacebook, BsLinkedin, BsInstagram, BsTwitter} from 'react-icons/bs'

const Footer = () => {
  return (
    <div className='bg-bg-primary text-white'>
      <div className='flex items-center justify-between py-6 px-24 '>
        <div className='font-bold text-xl'>
          HAKIM HUB
        </div>
        <div className='flex items-center gap-12 py-6 pr-8 '>
          <ul>
            <h2 className='font-semibold'>Get Connected</h2>
            <li className='flex items-center '>
              <svg
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              stroke="currentColor"
              className="h-4 w-4 text-white transform rotate-360"
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                strokeWidth="2"
                d="M9 5l7 7-7 7"
              ></path>
            </svg> 
            <span className='font-light text-sm' >For Physicians</span>
            </li>
            <li className='flex items-center '>
              <svg
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              stroke="currentColor"
              className="h-4 w-4 text-white transform rotate-360"
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                strokeWidth="2"
                d="M9 5l7 7-7 7"
              ></path>
            </svg> 
            <span className='font-light text-sm' >For Hospitals</span>
            </li>
          </ul>
          <ul>
            <h2 className='font-semibold'>Actions</h2>
            <li className='flex items-center '>
              <svg
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              stroke="currentColor"
              className="h-4 w-4 text-white transform rotate-360"
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                strokeWidth="2"
                d="M9 5l7 7-7 7"
              ></path>
            </svg> 
            <span className='font-light text-sm' >Find a Doctor</span>
            </li>
            <li className='flex items-center '>
              <svg
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              stroke="currentColor"
              className="h-4 w-4 text-white transform rotate-360"
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                strokeWidth="2"
                d="M9 5l7 7-7 7"
              ></path>
            </svg> 
            <span className='font-light text-sm' >Find a Hospital</span>
            </li>
          </ul>
          <ul>
            <h2 className='font-semibold'>Company</h2>
            <li className='flex items-center '>
              <svg
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              stroke="currentColor"
              className="h-4 w-4 text-white transform rotate-360"
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                strokeWidth="2"
                d="M9 5l7 7-7 7"
              ></path>
            </svg> 
            <span className='font-light text-sm' >About Us</span>
            </li>
            <li className='flex items-center '>
              <svg
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              stroke="currentColor"
              className="h-4 w-4 text-white transform rotate-360"
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                strokeWidth="2"
                d="M9 5l7 7-7 7"
              ></path>
            </svg> 
            <span className='font-light text-sm' >Career</span>
            </li>
            <li className='flex items-center '>
              <svg
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              stroke="currentColor"
              className="h-4 w-4 text-white transform rotate-360"
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                strokeWidth="2"
                d="M9 5l7 7-7 7"
              ></path>
            </svg> 
            <span className='font-light text-sm' >Join our team</span>
            </li>
          </ul>
        </div>
      </div>
      <hr className='text-white' />
      <div className='flex justify-between items-center px-12 py-4'>
        <div className=' flex justify-between  gap-12 items-center'>
          <p>Privacy Policy</p>
          <p>Terms of Use</p>
        </div>
        <div className=' flex items-center gap-12 pr-24'>
          <BsFacebook />
          <BsLinkedin />
          <BsInstagram />
          <BsTwitter />
        </div>
      </div>

    </div>
  )
}

export default Footer