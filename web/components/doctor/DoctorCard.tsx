"use client"

import {Doctor} from "@/type/doctor/doctor";
import Link from "next/link";


interface DoctorProps {
    doctor: Doctor;
}

const DoctorCard: React.FC<DoctorProps> = ({doctor}) => {
    return (
        <Link href={`/doctors/${doctor._id}`}>

            <div className=" flex flex-col items-center gap-4 justify-start py-7 px-4 rounded-lg shadow-lg shadow-gray-300">
                <img className="w-1/3 rounded-full -mt-16 bg-purple-700 p-0.5"
                     src={doctor.photo}/>

                <h2 className="font-poppins font-bold text-[1.2rem] overflow-ellipsis">{doctor.fullName}</h2>
                <div className="flex gap-1 flex-wrap">
                    {
                        doctor.speciality?doctor.speciality.map((special)=>{
                            return (
                                <button
                                    className="font-poppins text-[1rem] bg-primary text-white rounded-full px-2 py-0.5">
                                    {special.name}
                                </button>
                            )
                        }):<></>
                    }

                </div>

                <div className="flex gap-2 flex-wrap">
                    {
                        doctor.institutionID_list?doctor.institutionID_list.map((institution)=>{
                                return (
                                    <p className="font-poppins text-[0.8rem] font-light">
                                        {
                                            institution.institutionName
                                        }
                                    </p>
                                )
                            }
                        ):<></>
                    }
                </div>

            </div>
        </Link>
    )
}

export default DoctorCard;