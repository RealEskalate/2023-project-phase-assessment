import Image from 'next/image'

import { CiSearch } from 'react-icons/ci'

export default function Home() {
  return (
    <main className='font-poppins'>
      <div className='flex flex-row items-center justify-between rounded-full border max-w-3xl mx-auto px-6 py-2'>
        <input
          type="text"
          className='w-full outline-none bg-transparent text-sm'
          placeholder='Name'
        />
        <CiSearch
          className='text-gray-400 text-2xl'
        />
      </div>
    </main>
  )
}
