"use client";
import React from "react";
import Link from "next/link";
import { useGetDoctorsQuery } from "../lib/redux/features/doctor";
import DoctorCard from "./DoctorCard";

const CustomLoader = () => {
  return (
    <div className="flex items-center justify-center h-screen">
      <div className="animate-spin rounded-full h-16 w-16 border-t-4 border-red-500 border-solid"></div>
    </div>
  );
};

const DoctorCardList = ({ searchQuery, isSearching }: any) => {
  const { data, isLoading, error } = useGetDoctorsQuery();

  if (isLoading) {
    return <CustomLoader />; // Show the custom loader while loading
  }

  if (error) {
    return <div>Oops, something went wrong</div>; // Show the error message if there is an error
  }

  const doctors = data?.data;

  const filteredDoctors = doctors.filter((doctor: any) =>
    doctor.fullName.toLowerCase().includes(searchQuery.toLowerCase())
  );

  return (
    <div className="absolute top-[250px] left-[50px] grid grid-cols-4 gap-5">
      {isSearching && (
        <div className="grid grid-cols-4 gap-5">
          {filteredDoctors.map((doctor: any, index: any) => (
            <DoctorCard key={index} doctor={doctor} />
          ))}
        </div>
      )}
      {!isSearching && (
        <>
          {doctors.map((doctor: any) => (
            <Link href={`/doctor/${doctor._id}`} className="" key={doctor._id}>
              <DoctorCard doctor={doctor} />
            </Link>
          ))}
        </>
      )}
    </div>
  );
};

export default DoctorCardList;
