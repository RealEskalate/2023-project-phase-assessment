import Image from 'next/image'
interface DoctorCardProps {
    fullName: string;
    photo: string;
    speciality: string;
    mainInstitution: string;

}
export default function DoctorCard({fullName, photo, speciality, mainInstitution}: DoctorCardProps) {
    return <div className='flex flex-col items-center p-4 rounded-2xl shadow-2xl shadow-gray-200 space-y-6'>
    <img className='w-28 h-28 rounded-full border-[5px] border-[#6C63FF]' src={doctor.photo} alt="" />
    <h1>{doctor.fullName}</h1>
    {doctor.speciality && 
    <p className='bg-[#6C63FF] p-2 px-3 text-[#DDDCEF] rounded-full'>{doctor.speciality[0].name}</p>}
    {doctor.mainInstitution && <p>{doctor.mainInstitution.institutionName}</p> }
    </div>
}