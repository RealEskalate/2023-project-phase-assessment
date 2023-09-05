import {useGetDoctorByIdQuery} from '@/store/features/doctors/doctors-api'


const DoctorPage:React.FC = ({
    params: { id },
  }: {
    params: { id: string }
  }) = > {

    const [doctor, isLoading, error] = useGetDoctorByIdQuery(id)

    return (
        <div>
        </div>
    )

}

export default DoctorPage