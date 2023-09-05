"use client";
import React from "react";
import DoctorImageCard from "./DoctorImageCard";
import InfoCard from "./InfoCard";
import { useGetDoctorByIdQuery } from "@/lib/redux/services/doctorsApi";
interface Prop {
  id: string;
}
export default function DoctorDetail({ id }: Prop) {
  const { data, isLoading, error } = useGetDoctorByIdQuery(id);

  return (
    <div>
      <div>
        <DoctorImageCard doctorImage={data?.photo} />
      </div>
      <div>
        <InfoCard
          name={data?.fullName}
          speciality={data?.speciality[0].name}
          institution=""
          summary=""
        />
      </div>
    </div>
  );
}
