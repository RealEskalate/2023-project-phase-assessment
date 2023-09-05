import React from 'react'
import Image from 'next/image'

const ProfileCard = () => {
  return (
    <div className='m-20 shadow-xl rounded-2xl w-80 flex flex-col items-center justify-center'>
      <Image 
        src='Ellipse 27.svg'
        width={90}
        height={89}
        alt="picture"
        className='mt-5'
        />
        <div className='text-lg font-semibold '>Dr. Biruk Fikadu</div>
        <div className='font-light text-sm bg-button inline-block w-auto rounded-lg text-white p-1 mt-2'>Pediatrician</div>
        <div className='text-center text-description text-sm font-normal my-6 px-2 mb-8'>Washington Medical Center | MCM korean Hospital</div>
    </div>
  )
}

export default ProfileCard
