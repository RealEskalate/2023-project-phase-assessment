import React from 'react'
import {AiOutlineRight} from 'react-icons/ai'
import {ImFacebook} from 'react-icons/im'
import {GrLinkedin} from 'react-icons/gr'
import {BsInstagram} from 'react-icons/bs'
import {AiFillTwitterCircle} from 'react-icons/ai'


const Footer = () => {
  return (
    <div className='bg-blue-700 text-white h-[220px] pt-10 bottom-0 w-full mb-0 '>
        <div className=' flex pb-3'>
            {/* name */}
            <div className='text-2xl text-white font-bold pl-8 w-1/2 '>HakimHub</div>
            {/* getconn, action, company */}
            <div className='w-1/2 text-sm flex space-x-10 justify-evenly'> 
            <div className='space-y-2'>
                <h3 className='font-bold'>Get Connected</h3>
                <div className='flex space-x-2 text-xs'> 
                    <div className='pt-1'><AiOutlineRight size= {10}/></div>
                    <div> For Physicians</div>
                </div>
                <div className='flex space-x-2 text-xs'> 
                    <div className='pt-1'><AiOutlineRight size= {10}/></div>
                    <div> For Hospitals</div>
                </div>
                
                
            </div>
            <div className='space-y-2'>
                <h3 className='font-bold'>Actions</h3>
                <div className='flex space-x-2 text-xs'> 
                    <div className='pt-1'><AiOutlineRight size= {10}/></div>
                    <div> Find a doctor</div>
                </div>
                <div className='flex space-x-2 text-xs'> 
                    <div className='pt-1'><AiOutlineRight size= {10}/></div>
                    <div> Find a Hospital</div>
                </div>
                
            </div>
            <div className='space-y-2'> 
                <h3 className='font-bold'>Company</h3>
                <div className='flex space-x-2 text-xs'> 
                    <div className='pt-1'><AiOutlineRight size= {10}/></div>
                    <div> About Us</div>
                </div>
                <div className='flex space-x-2 text-xs'> 
                    <div className='pt-1'><AiOutlineRight size= {10}/></div>
                    <div> Career</div>
                </div>
                <div className='flex space-x-2 text-xs'> 
                    <div className='pt-1'><AiOutlineRight size= {10}/></div>
                    <div> Join out team</div>
                </div>
                
            </div>

            </div>
        </div>
        <hr className="border-purple-400 pr-10 pt-7"/>
        <div className='flex'>
            {/* pr, ter */}
            <div className='flex justify-evenly w-1/3 pl-14 pr-20 text-xs font-semibold'>
                <div>Privacy Policy</div>
                <div>Terms of Use</div>
            </div>
            {/* social media links */}
            <div className='flex justify-center space-x-10 bg-transparent w-2/3 pl-56'>
                <div><ImFacebook /></div>
                <div><GrLinkedin /></div>
                <div><BsInstagram /></div>
                <div><AiFillTwitterCircle  /></div>

            </div>

        </div>

    </div>
  )
}

export default Footer