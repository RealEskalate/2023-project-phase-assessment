"use client";

import React, { useState } from "react";
import {
  useGetDoctorsQuery,
  useSearchDoctorsQuery,
} from "@/store/features/doctor/doctor-api";
import DoctorCard from "./DoctorCard";
import { AllDoctorResponse } from "@/types/AllDoctorResponse";
import SearchBar from "./SearchBar";
import Loading from "./Loading";


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

  const [searchKeyword, setSearchKeyword] = useState<string>("");

  const { data: searchResults, isLoading: isSearchLoading } =
    useSearchDoctorsQuery(searchKeyword);

  if (isLoading) {
    return (
      <div>
        <Loading />
      </div>
    );
  }

  if (isError) {
    return <div>Error fetching data.</div>;
  }

  return (
    <div className="mx-12">
      <SearchBar
        searchKeyword={searchKeyword}
        setSearchKeyword={setSearchKeyword}
      />

      <div className="grid grid-cols-4 gap-4">
        {(searchKeyword ? searchResults?.data : doctorsList?.data)?.map(
          (doctor) => (
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
          )
        )}
      </div>
    </div>
  );
};

export default DoctorContainer;
