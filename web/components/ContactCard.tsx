import React from 'react'
import {BiSolidPhone} from 'react-icons/bi'
import {MdEmail} from 'react-icons/md'

const ContactCard = () => {
  return (
    <div className='flex-col space-y-3 pb-10'>
        <h2 className='font-bold py-6'>Contact Info</h2>
        <div className='flex space-x-3'>
            <BiSolidPhone />
            <div>
                <h5 className='text-blue-500 text-sm font-bold'>Phone Number</h5>
                <p className='text-gray-700'>+251 908820458</p>

            </div>
            

        </div>
        <div className='flex space-x-3'>
            <MdEmail />
            <div >
                <h5 className='text-blue-500 text-sm font-bold'>Email</h5>
                <p className='text-gray-700'>ruth@gmail.com </p>
            </div>
            
        </div>

    </div>
  )
}

export default ContactCard