import React from 'react'
import Image from 'next/image';
import ArrowRight from '@/assets/Images/arrowRight.png';
import FacebookIcon from '@/assets/Images/Facebook.png';
import LinkedInIcon from '@/assets/Images/Linkedin.png';
import InstagramIcon from '@/assets/Images/Instagram.png';
import TwitterIcon from '@/assets/Images/Twitter.png';

import { Poppins } from 'next/font/google'

const popins = Poppins({ weight: '700', subsets: ['latin'] })
const popinsLight = Poppins({ weight: '200', subsets: ['latin'] })

const Footer = () => {
  return (
    <div className='w-full bg-[#7879F1] flex flex-col flex-wrap sm:pr-32 text-white pt-20 mt-40'>
        <div className='border-b-[1px] flex-wrap border-white/50 flex justify-between w-full pl-10'>
            <h1 className={`${popins.className} text-3xl`}>HakimHub</h1>
            <div className='flex gap-14 pb-20'>
                <div className=''>
                    <h2 className={`${popins.className}`}>Get Connected</h2>
                    <div className={`${popinsLight.className} text-md flex flex-col gap-4`}>
                        <div className='flex gap-2 mt-4'>
                            >
                            <p>For Physicians</p>
                        </div>
                        <div className='flex gap-2'>
                            >
                            <p>For Hospitals</p>
                        </div>
                    </div>
                </div>
                <div className=''>
                    <h2 className={`${popins.className}`}>Actions</h2>
                    <div className={`${popinsLight.className} text-md flex flex-col gap-4`}>
                        <div className='flex gap-2 mt-4'>
                            >
                            <p>Find a doctor</p>
                        </div>
                        <div className='flex gap-2'>
                            >
                            <p>Find a hospital</p>
                        </div>
                    </div>
                </div>
                <div className=''>
                    <h2 className={`${popins.className}`}>Company</h2>
                    <div className={`${popinsLight.className} text-md flex flex-col gap-4`}>
                        <div className='flex gap-2 mt-4'>
                            >
                            <p>About Us </p>
                        </div>
                        <div className='flex gap-2'>
                            >
                            <p>Career</p>
                        </div>
                        <div className='flex gap-2'>
                            >
                            <p>Join our team</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div className='flex mt-20 sm:mt-0 justify-between flex-wrap w-full pl-20 py-4 pr-10'>
            <div className={`flex gap-20 ${popins.className}`}>
                <h1>Privacy Policy</h1>
                <h1>Terms of Use</h1>
            </div>
            <div className='flex gap-14 flex-wrap mt-10 md:mt-0'>
                <Image src={FacebookIcon} alt="facebook" height={4} width={25}/>
                <Image src={LinkedInIcon} alt="linkedin" height={4} width={25}/>
                <Image src={InstagramIcon} alt="instagram" height={4} width={25}/>
                <Image src={TwitterIcon} alt="twitter" height={4} width={25}/>
            </div>
        </div>
    </div>
  )
}

export default Footer