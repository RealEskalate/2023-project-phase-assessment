import Image from "next/image"
import { useParams } from "next/navigation"
import { useGetDoctorProfileQuery } from "@/store/apiSlice"

const Details = () => {
    const id = useParams()
    const{data:doctors, isSuccess} = useGetDoctorProfileQuery(id)

  return (
        {
            doctors?.data.map((doctor:any)=>{
                <div className="flex flex-col max-h-screen">
                    <div className="w-[1268px] h-[288px] pt-8 flex flex-col">
            <Image src = "/images/manik.svg" width={1268} height= {288} alt=""/>
            <Image src={doctor.photo} width={227} height={227} alt="" className="rounded-full -pb-[50%]"/>
        </div>
        <div className="flex flex-row justify-between">
            <div className="flex flex-col">
            <h3 className="font-poppins font-normal text-3xl">Dr Fasil Tefera</h3>
            <p className="font-poppins font-light">Internal Medicine</p>
            </div>
            <div className="flex flex-col">
                <p className="font-poppins font-normal text-2xl">Addis Ababa University</p>
                <p className="font-poppins font-normal text-2xl text-center">Washington Medical Center</p>
            </div>

        </div>

        <div className="flex flex-col">
            <h3 className="font-poppins font-bold text-xl">About</h3>
            <p className="font-poppins font-light">{doctor.summery}</p>
        </div>
        <div className="flex flex-col">
            <h3 className="font-poppins font-bold text-xl">Education</h3>
            <div>
                <div className="flex flex-row justify-between">
                    <div className="flex flex-col">
                    <p className="font-poppins font-medium text-xl ">Addis Ababa University</p>
                    <p className="font-poppins font-normal">B.Sc Medicine</p>
                    </div>
                    <div>
                        <p className="font-poppins font-light text-xl text-justify">2003 - 2007</p>
                    </div>
                </div>
                <div className="flex flex-row justify-between">
                    <div className="flex flex-col">
                    <p className="font-poppins font-medium text-xl ">Harvard University</p>
                    <p className="font-poppins font-normal">M.Sc Internal Medicine</p>
                    </div>
                    <div>
                        <p className="font-poppins font-light text-xl text-justify">2003 - 2007</p>
                    </div>
                </div>

            </div>
        </div>

        <div className="ml-2 mr-auto">
            <h3>Contact Info</h3>
            <div>
            <p><Image src="/images/phone.svg" width={18} height={14} alt=""/><span className="font-poppins font-bold text-xl">Phone Number:</span></p>
            <p className="font-poppins font-normal text-xl">+25111763498</p>
            </div>
            <div>
            <p><Image src="/images/email" width={18} height={14} alt=""/><span>Email:</span></p>
            <p>faakldfjdsak</p>
            </div>
        </div>

                </div>
            })
        }
  )
}

export default Details