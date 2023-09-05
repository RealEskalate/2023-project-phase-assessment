'use client'
import { useGetSingleDoctorQuery } from "@/store/features/doctors/doctors-api";
import { useParams } from "next/navigation";

const SingleDoctor = () => {
    const {id} = useParams()
    const {isLoading,isSuccess,isError,error,data} = useGetSingleDoctorQuery(id as string)
    return ( <div>
        {isLoading&&<p className="text-6xl h-screen text-center">loading...</p>}
        {isSuccess&&<div className="flex flex-col px-32 items-start w-full relative pb-32">
            <div style={{backgroundImage:"url('/images/stethoscope.jpg')"}} className="h-40 w-full bg-cover bg-center rounded-xl"></div>
            <div className="flex w-full justify-center">
                <div className="rounded-full absolute top-16 mx-auto overflow-hidden w-36 h-36">
                    <img src={data.photo} alt="" className="mx-auto"/>
                </div>
            </div>
            
            <div className="mt-32 flex justify-between w-full px-10 md:px-0 my-10">
                <div>
                    <h1 className="text-4xl font-semibold">{data.fullName}</h1>
                    <p className="text-gray-700">{data.speciality[0].name}</p>
                </div>
                <p className="flex flex-col text-gray-600">{data.institutionID_list.map((inst:any)=><p>{inst.institutionName}</p>)}</p>
            </div>
            <h2 className="font-bold my-5">About</h2>
            <p className="w-3/4">Lorem, ipsum dolor sit amet consectetur adipisicing elit. Non a tenetur asperiores saepe quas! Laborum saepe animi voluptatum iure perspiciatis aperiam magni similique eum quam. Distinctio, atque repudiandae at dolorum earum quidem culpa alias iusto omnis officia corrupti, doloremque adipisci, accusamus beatae quam nisi. Nemo vel inventore doloremque molestias expedita.</p>
            
            {data.education.length>0 && <div>
                <h2>Education</h2>
                    {data.education.map((ed:any)=>{
                        ed.university
                    })}
                </div>}
            <h2 className="mt-5">Contact Info</h2>
            <p className="font-bold">Phone Number</p>
            {data.phone&&<div>
                {data.phone.map((e:string)=>(<p key={e}>{e}</p>))}
            </div>}
            
            <p className="font-bold">Email</p>
            {data.emails.map((e:string)=>(<p key={e}>{e}</p>))}
        </div>}
    </div> );
}
 
export default SingleDoctor;