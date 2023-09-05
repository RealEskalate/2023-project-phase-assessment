import React from 'react'
import Link from 'next/link'
import { BsInstagram, BsFacebook, BsTwitter } from 'react-icons/bs'
import { FaLinkedinIn } from 'react-icons/fa'

export default function Footer() {
  const getConnectedLinks = [
    {
      title: 'For Physicians',
      link: '#'
    },
    {
      title: 'For Hospitals',
      link: '#'
    }
  ];

  const actionsLinks = [
    {
      title: 'Find a doctor',
      link: '#'
    },
    {
      title: 'Find a hospital',
      link: '#'
    }
  ];

  const companyLinks = [
    {
      title: 'About Us',
      link: '#'
    },
    {
      title: 'Career',
      link: '#'
    },
    {
      title: 'Join our team',
      link: '#'
    }
  ];

  return (
    <footer className='bg-secondary font-poppins text-white'>
      <div className='flex justify-between items-start mx-20 py-20 border-b border-white'>
        <div className='text-3xl font-bold'>HakimHub</div>
        <div className='flex text-md space-x-36'>
          <div className=''>
            <h5 className='font-semibold'>Get Connected</h5>
            <ul className='mt-3 text-sm flex flex-col space-y-3'>
              {
                getConnectedLinks.map(link => (
                  <li key={ link.title }>
                    <Link href={ link.link }>&gt; { link.title }</Link>
                  </li>
                ))
              }
            </ul>
          </div>
          <div>
            <h5 className='font-semibold'>Actions</h5>
            <ul className='mt-3 text-sm flex flex-col space-y-3'>
              {
                actionsLinks.map(link => (
                  <li key={ link.title }>
                    <Link href={ link.link }>&gt; { link.title }</Link>
                  </li>
                ))
              }
            </ul>
          </div>
          <div>
            <h5 className='font-semibold'>Company</h5>
            <ul className='mt-3 text-sm flex flex-col space-y-3'>
              {
                companyLinks.map(link => (
                  <li key={ link.title }>
                    <Link href={ link.link }>&gt; { link.title }</Link>
                  </li>
                ))
              }
            </ul>
          </div>
        </div>
      </div>
      <div className='flex justify-between items-center mx-20 text-sm py-4'>
        <div className='flex space-x-40 text-sm font-semibold'>
          <Link href='#'>Privacy Policy</Link>
          <Link href='#'>Terms of Use</Link>
        </div>
        <div className='flex space-x-9 text-xl'>
          <BsFacebook />
          <FaLinkedinIn />
          <BsInstagram />
          <BsTwitter />
        </div>
      </div>
    </footer>
  )
}
