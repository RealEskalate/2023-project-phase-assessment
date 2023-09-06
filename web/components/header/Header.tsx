import Image from 'next/image';

const Header: React.FC = () => {

    return (
        <div className='w-screen  mt-0 py-5 px-20'>
            <nav className="w-full flex justify-between">
                <div className='relative'>
                    <Image src='/assets/img/hakim-logo.png' alt='logo image' className='absolute z-10' objectFit='cover' fill={true} />
                </div>
                <div className='flex gap-2'>
                    <div className='relative'>
                        <Image src='/assets/img/hakim-account.png' alt='account image'className='absolute z-10' objectFit='cover' fill={true} />
                    </div>
                    <div className=''>Yakin Teshome </div>
                </div>

            </nav>

        </div>
    )
}
    export default Header