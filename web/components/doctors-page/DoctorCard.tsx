import Image from 'next/image'

const DoctorCard = ({ doctor }) => {

    return (
        <div className='flex flex-col p-3 shadow-lg rounded-xl w-[300px] font-poppins'>
            <div className='relative w-[90px] h-[90px] border-primary border-3 bg-gray-400'>
            
            </div>
            <h3 className='mt-3 font-semibold text-[18px]'>Yakin Teshome</h3>
            <div className='mt-4 bg-primary text-white text-lg'>Specialty</div>
            <p className='mt-7 text-center text-[#686868] text-lg'>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dicta labore, in, recusandae nobis perspiciatis maxime id dolorem.</p>
        </div>
    )
}

export default DoctorCard