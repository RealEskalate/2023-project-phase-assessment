'use client'
import Image from "next/image"
import SearchBar from "./SearchBar"
import { useGetAllDoctorsQuery } from "@/store/apiSlice"
import { useRouter } from "next/navigation"
import Link from 'next/link'

const Home = () => {
    const{data:doctors, isSuccess, isLoading, isError} = useGetAllDoctorsQuery()
    const router = useRouter()
  return (
    <div className="flex flex-col items-center gap-12 text-black">
        <SearchBar/>
        <div className="grid grid-cols-4 gap-4 pb-4">
        {
            doctors?.data.map((doctor)=>{
                return(
                <div key={doctor._id} className="flex flex-col items-center gap-2 bg-white rounded-md shadow-lg p-8">
                    <Image src={doctor.photo} className="rounded-full" border-blue-500 height={98} width={90} alt="`${doctor.fullName}`"/>
                    <p className="font-poppins font-normal text-xl text-black">{doctor.fullName}</p>
                    <div className="text-white text-center bg-sub-primary rounded-md w-32">
                        {doctor.speciality.map((special)=>{
                        return <p key={special._id}>{special.name}</p>
                    })}
                    </div>
                    <div>
                        {doctor.institutionID_list.map((item)=>{
                            return <p>{item.institutionName}</p>
                        })}
                    </div>     
                    <button onClick={()=>router.push(`/details/${doctor._id}`)}>
                        Detail
                    </button>               
                </div>)
            })
        }
        </div>
        
    </div>
  )
}

export default Home