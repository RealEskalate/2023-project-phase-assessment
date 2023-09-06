import Image from 'next/image'

const DoctorCard = ({ doctor }) => {

    return (
        <div className='flex flex-col p-3 shadow-lg rounded-xl w-[300px] font-poppins'>
            <div className='relative w-[90px] h-[90px] rounded-[45px] border-primary border-3 bg-gray-400 mx-auto'>
            <Image src={doctor.photo} alt='profilr photo' className='absolute' objectFit='cover' fill={true}/>
            </div>
            <h3 className='mt-3 font-semibold text-[18px]'>{doctor.fullName}</h3>
            <div className='mx-auto bg-primary text-white rounded-full text-lg w-fit px-4 py-3'>{doctor.speciality.name}</div>
            <p className='mt-7 text-center text-[#686868] text-lg'>{doctor.institutionID_list.institutionName}</p>
        </div>
    )
}

export default DoctorCard