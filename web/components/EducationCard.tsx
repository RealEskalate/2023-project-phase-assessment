import React from 'react'

const EducationCard = () => {
  return (
    <div className='flex justify-between space-y-3 border rounded-lg border-gray-100 p-3 '>
        <div>
        <h2 className='font-semibold text-gray-800'>Education title</h2>
        <p className='text-sm    font-normal text-gray-700 '>specialization type</p>
    </div>
    {/* date */}
    <div className='text-gray-500'>
        2003 - 2007
    </div>
    
    </div>
    

  )
}

export default EducationCard