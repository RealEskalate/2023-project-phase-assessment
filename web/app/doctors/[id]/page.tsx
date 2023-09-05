import {useGetDoctorByIdQuery} from '@/store/features/doctors/doctors-api'


const DoctorPage:React.FC = () = > {

    const [doctor, isLoading, error] = useGetDoctorByIdQuery()

    return (
        <div>{doctor.name}</div>
    )

}

export default DoctorPage