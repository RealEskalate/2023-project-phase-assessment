import Link from 'next/link'

import { useGetDoctorsMutation } from '@/store/features/doctors/doctors-api'
import DoctorCard from '@/components/doctors-page/DoctorCard'
import SearchBar from '@/components/header/SearchBar'


const DoctorsPage: React.FC = () => {

    const [doctors, status, error, isLoading] = useGetDoctorsMutation()

    if (isLoading) {
        return <div>Loading...</div>
    }
    console.log(doctors)
    return (
        <div className='w-11/12 mx-auto mt-20'>
            <SearchBar/>
            <div className='w-full grid grid-cols-auto-1 gap-5'>
                {
                    doctors.map((doctor, index) => {
                        return (<Link prefetch href={`/doctors/${doctor.id}` }>
                            <DoctorCard key={index} doctor={doctor} />
                        </Link>)
                    })
                }
            </div>

        </div>
    )
}

export default DoctorsPage