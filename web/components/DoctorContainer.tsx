"use client";

import React from "react";
import { useGetDoctorsQuery } from "@/store/features/doctor/doctor-api";
import DoctorCard from "./DoctorCard";
import { AllDoctorResponse } from "@/types/AllDoctorResponse";

type RTKReponse = {
  data?: AllDoctorResponse;
  isLoading: boolean;
  isError: boolean;
};

const DoctorContainer = () => {
  const {
    data: doctorsList,
    isLoading,
    isError,
  }: RTKReponse = useGetDoctorsQuery();

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError) {
    return <div>Error fetching data.</div>;
  }

  return (
    <div className="grid grid-cols-4 gap-4 mx-12">
      {doctorsList?.data.map((doctor) => (
        <DoctorCard
          key={doctor._id}
          id={doctor._id}
          name={doctor.fullName}
          photoUrl={doctor.photo}
          speciality={doctor.speciality[0]?.name || "Unknown Speciality"}
          hospital={
            doctor.institutionID_list[0]?.institutionName ||
            "Unknown Institution"
          }
        />
      ))}
    </div>
  );
};

export default DoctorContainer;
