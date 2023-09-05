import Image from 'next/image';

const Header: React.FC = () => {

    return (
        <div className='fixed top-0 left-0 right-0'>
            <nav className="w-full flex justify-between">
                <div className='relative'>
                    <Image src='/assets/img/hakim-logo.png' className='absolute' objectFit='cover' fit={true} />
                </div>
                <div className='flex gap-2'>
                    <div className='relative'>
                        <Image src='/assets/img/hakim-account.jfif' className='absolute' objectFit='cover' fit={true} />
                    </div>
                    <div className=''>Yakin Teshome </div>
                </div>

            </nav>

        </div>
    )
}
    export default Header