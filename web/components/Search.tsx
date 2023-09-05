import {BiSearchAlt} from 'react-icons/bi'

export default function Search() {
    return (
        <div
        className="w-10/12 mx-auto">
            <div className='border-2 w-full h-12 rounded-full flex justify-between items-center px-6'>
            <input type="text" className='h-full flex-grow focus:outline-none' />

            <BiSearchAlt className=' text-3xl text-gray-400 hover:scale-105'/>
            </div>
        </div>
    )
}