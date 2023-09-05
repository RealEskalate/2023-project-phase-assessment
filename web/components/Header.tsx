'use client'
import Image from 'next/image'
import Link from 'next/link';

const Header = () => {
    return ( <header className="flex justify-between py-10 px-20 flex-col md:flex-row">
        <Image src={"/images/hakim-hub-logo.png"} width={300} height={100} alt='hakim hub logo'/>
        <div className='flex gap-6'>
            <div className="rounded-full overflow-hidden">
                <Image src={"/images/profile.png"} width={75} height={100} alt='profile'/>
            </div>
            <Link href={""} className='flex items-center justify-between gap-4 font-poppins text-gray-600 text-lg'>Jonathan Alemayehu <Image src={"/images/down.png"} width={15} height={15} alt='down arrow'/></Link>
        </div>
    </header> );
}
 
export default Header;