import Image from 'next/image'
import Vector from '../public/Vector.png'
import profile from '../public/profile.png'
import {AiOutlineDown} from 'react-icons/ai'
export default function Navbar() {
    return (
    <nav className='p-4 flex justify-between px-10'>
        <div className='flex items-center space-x-4'>
            <Image className='inline-block h-10 w-10' src={Vector} alt="Vector" />
            <h1 className='text-2xl font-bold text-[#424242]'>Hakim<span
            className='text-[#FF7272]'>Hub</span></h1>
        </div>

        <div className='flex space-x-4 items-center'>
            <Image className='h-14 w-14' src={profile} alt='profile image'/>
            <p>Jonathan Alemayehu</p>
            <AiOutlineDown className=''/>
        </div>
    </nav>
    )
}