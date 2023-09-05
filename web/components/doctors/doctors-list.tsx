'use client'
import DoctorCard from "@/components/doctors/doctorscard";
import {
  useGetDoctorsMutation,
} from "@/store/features/api";
import { Daum } from "@/types/doctors-list";
import React from "react"
import { useEffect, useState } from "react";

const DoctorsList = () => {
  const [getDoctors, { isLoading, isSuccess, isError, error,data}] = useGetDoctorsMutation();
  


  // const [doctors, setDoctors] = useState<Daum[]>([]);
  // const handleGetDoctors = async () => {
  //   try {
  //     const response = await getDoctors();
  //     setDoctors(response.data.data);
  //     console.log(response.data.data)
  //   } catch (error) {
  //     console.log(error);
  //   }
  // };
  // console.log(data)
  useEffect(() => {
    getDoctors();
  }, []);

  if (isError) {
    return <div>No doctors</div>;
  }
  console.log(isSuccess,isLoading,data)
  return (
    <section>
      {!isSuccess  ? (
        <div className="my-auto">Loading... </div>
      ) : (
        <div className="flex flex-wrap gap-16">
          console.log(data)
          {isSuccess && data.data.map((doctor:any) => (
              <DoctorCard {...doctor} />
          ))}
        </div>
      )}
    </section>
  );
};

export default DoctorsList;