"use client";

import { useGetDoctorsQuery } from "@/store/features/doctors/doctorsApi";
import React from "react";
import SingleDoctor from "./SingleDoctor";
import { Doctor } from "@/types/Doctor";
import Image from "next/image";

const DoctorsPage = () => {
  const { data, error, isError, isLoading } = useGetDoctorsQuery();
  console.log(data);

  if (isLoading) {
    return (
      <div className="text-4xl font-bold w-full text-center">Loading...</div>
    );
  } else if (isError) {
    return (
      <div className="text-4xl font-bold w-full text-center">
        {(error as any).data?.message}
      </div>
    );
  }

  return (
    <div>
      <div className="w-2/3 mx-auto mb-10 relative">
        <input
          className="block w-full outline outline-gray-200 py-2 px-6 rounded-full mb-30"
          placeholder="Name"
        />
        <Image src={"./search/search.svg"} alt={"Search logo"} width={20} height={20} className="absolute top-3 right-6"/>
      </div>
      <div className="mt-10 w-3/4 mx-auto grid grid-cols-4 gap-x-4 gap-y-5">
        {data?.data?.map((doctor: Doctor) => (
          <SingleDoctor
            key={doctor._id}
            _id={doctor._id}
            availability={doctor.availability}
            photo={doctor.photo}
            summary={doctor.summary}
            speciality={doctor.speciality}
            experience_years={doctor.experience_years}
            institutionID_list={doctor.institutionID_list}
            gender={doctor.gender}
            languages={doctor.languages}
            birthday={doctor.birthday}
            otherDocuments={doctor.otherDocuments}
            experience={doctor.experience}
            fullName={doctor.fullName}
            mainInstitution={doctor.mainInstitution}
            education={doctor.education}
            __v={doctor.__v}
            fullName_fuzzy={doctor.fullName_fuzzy}
            emails={doctor.emails}
            phoneNumbers={doctor.phoneNumbers}
            score={doctor.score}
            source={doctor.source}
          />
        ))}
      </div>
    </div>
  );
};

export default DoctorsPage;
