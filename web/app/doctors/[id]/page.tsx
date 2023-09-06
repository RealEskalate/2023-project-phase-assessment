"use client"
import { useGetDoctorByIdQuery } from '@/store/features/doctors/doctors-api'


const DoctorPage: React.FC = ({
  params: { id },
}: {
  params: { id: string }
}) => {

  const { data: doctor, isLoading, error } = useGetDoctorByIdQuery(id as string)

  console.log(doctor)

  return (
    <div className='w-11/12 flex flex-col mx-auto mt-20'>
      <div className=' flex flex-col h-[460px] w-full '>
        <div className='relative w-ful h-3/4 bg-gray-300'>
          {/* image */}
        </div>
        <div className='relative items-end justify-center z-10 w-[230px] h-[230px] rounded-[115px] border-primary border-3'>
          <Image src={doctor?.photo} alt='profile image' className='absolute' objectFit='cover' fill={true} />
        </div>
      </div>
      <div className='flex flex-col w-3/5 justify-start'>
        <div className='w-full flex flex-col mt-10'>
          <div className='flex flex-row items-start justify-start'>
            <div className='flex-1 flex flex-col items-start justify-start'>
              <h3 className='font-semibold text-2xl'>{doctor?.fullName}</h3>
              <h4 className='text-lg capitalize '>Internal Medicine</h4>
            </div>
            <div className='flex-1 flex flex-col items-start justify-start'>
              <h4 className='text-lg capitalize '>Addis Ababa University</h4>
              <h3 className='text-xl'>Washington Medical center</h3>
            </div>
          </div>

        </div>
        <div className='w-full flex flex-col items-start justify-start'>
          <h3 className='text-2xl font-semibold text-left my-5'>About</h3>
          <p className='text-xl text-left'>{doctoritem?.summary}
          </p>

        </div>
        <div className='w-full flex flex-col mt-10'>
          <div className='w-full flex flex-row items-start justify-start'>
            <div className=' w-full flex flex-col items-start justify-start'>
              <div className='text-2xl font-semibold text-left my-5'>Education</div>
              <div className='w-full flex flex-row items-start justify-start'>
                <div className='w-full flex-1 flex flex-col items-start justify-start py-10'>
                  <h3 className='font-semibold text-2xl'>Addis Ababa University</h3>
                  <h4 className='text-lg capitalize '>B. Sc Medicine</h4>
                </div>
                <div className='w-full flex-1 flex flex-col items-start justify-start py-10'>
                  <h4 className='text-lg capitalize '>2003 - 2007</h4>
                  <h3 className='text-xl'>2003 - 2007</h3>
                </div>
              </div>
            </div>
          </div>

        </div>
        <div className='w-full flex flex-col mt-10'>
          <div className='w-full flex flex-row items-start justify-start'>
            <div className=' w-full flex flex-col items-start justify-start'>
              <div className='text-2xl font-semibold text-left my-5'>Contacts</div>
              <div className='w-full flex flex-row items-start justify-start'>
                <div className='w-full flex-1 flex flex-col items-start justify-start py-10'>
                  <h3 className='font-semibold text-2xl'>Addis Ababa University</h3>
                  <h4 className='text-lg capitalize '>B. Sc Medicine</h4>
                </div>
                <div className='w-full flex-1 flex flex-col items-start justify-start py-10'>
                  
                </div>
              </div>
            </div>
          </div>

        </div>
        

      </div>
    </div>
  )

}

export default DoctorPage