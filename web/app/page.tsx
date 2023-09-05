"use client";

import Loading from "@/components/common/Loading";
import DoctorCard from "@/components/home/DoctorCard";
import { useGetDoctorsQuery } from "@/store/features/doctors/doctors-api";
import { useGetSearchResultQuery } from "@/store/features/search_doctor/search-doctor-api";
import { usePathname } from "next/navigation";
import Link from "next/link";
import { useState } from "react";
import { BsSearch } from "react-icons/bs";

export default function Home() {
  const {
    data: doctors,
    error: getError,
    isLoading: getLoading,
  } = useGetDoctorsQuery();
  const [name, setName] = useState("");
  const { data: result, error, isLoading } = useGetSearchResultQuery(name);
  const path = usePathname();

  if (isLoading) return <Loading />;
  else {
    return (
      <div className="h-[100%] flex flex-col gap-28 mx-0 md:mx-24 my-10">
        <div className="flex items-center relative px-10 md:px-32">
          <input
            type="text"
            placeholder="Name"
            value={name}
            className="border border-[#DFDFE2] rounded-full py-3 px-6 w-full"
            onChange={(e) => setName(e.target.value)}
          />
          <BsSearch className="text-[#D6D1D1] w-6 h-6 absolute right-16 md:right-40" />
        </div>
        <div className="flex gap-x-6 gap-y-20 flex-wrap justify-evenly">
          {!isLoading && !doctors && (
            <p className="flex justify-center">No available Doctors yet...</p>
          )}
          {doctors &&
            result?.data.map((doctor) => (
              <Link href={path + "doctor/" + doctor._id}>
                <DoctorCard doctor={doctor} />
              </Link>
            ))}
        </div>
        <div className="flex justify-center">...Pagination...</div>
      </div>
    );
  }
}
