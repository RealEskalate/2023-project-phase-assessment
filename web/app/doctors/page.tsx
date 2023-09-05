"use client"

import { FaSearch } from 'react-icons/fa';
import DoctorCard from "@/components/doctor/DoctorCard";
import Loading from "@/components/commons/Loading"

import {useGetDoctorsQuery, useSearchDoctorsQuery} from "@/store/features/doctors-api";
import {useState} from "react";
import Pagination from "@/components/doctor/Pagination";



const DoctorsList = ()=>{

    const [page, setPage] = useState(1)

    const [searchTerm, setSearchTerm] = useState('');

    const goToPage = (pageNumber: number) => {
        setPage(pageNumber);
    };

    const {isLoading, data, isError, isSuccess} = useSearchDoctorsQuery({keyword: searchTerm, institutions:false, articles:false, from:page, size:12})

    const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setSearchTerm(event.target.value);
    };


        return (
            <>
                <section className="w-full font-poppins">

                    <div className="w-10/12 rounded-full m-auto flex justify-between py-2 px-4 border-2 border-black">
                        <input type="text" placeholder="Name" className="outline-0 w-10/12" value={searchTerm} onChange={handleInputChange} />
                        <FaSearch className="w-6 h-6" />
                    </div>
                    {
                        isLoading?(
                            <Loading />
                            )
                            :isError?(
                                <p className="text-5xl">
                                    Error
                                </p>
                            )
                                :isSuccess?
                                    data.data.length>0?
                                        (
                                            <>
                                                <div className="m-auto w-11/12 grid lg:grid-cols-4 md:grid-cols-3 sm:grid-cols-2 grid-cols-1 gap-y-12 gap-x-4 mt-20">
                                                    {
                                                        data.data.map((doctor)=>{
                                                            return <DoctorCard key={doctor._id} doctor={doctor}  />
                                                        })
                                                    }
                                                </div>

                                                <div className="flex gap-3 w-fit mx-auto mt-20">
                                                    {
                                                        Array.from({ length: Math.ceil(data.totalCount/12) }, (_, index) => index).map((num)=>{
                                                            return (
                                                                <Pagination num={num} goToPage={goToPage} page={page} />
                                                            )
                                                        })
                                                    }
                                                </div>
                                            </>

                                        ):<p className="w-full flex justify-center mx-auto my-auto mt-20 text-[1.5rem] font-bold font-poppins"> No Doctors Found! </p>:<></>
                    }

                </section>
            </>
        )
}

export default DoctorsList