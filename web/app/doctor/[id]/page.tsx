"use client";
import { useGetDoctorQuery } from "@/store/features/profile/doctor-profile-id-api";
import { useParams } from "next/navigation";

const doctorDetail = () => {
  const path = useParams();
  const {
    data: doctor,
    error,
    isLoading,
  } = useGetDoctorQuery(path.id as string);

  return (
    <div>
      <div></div>
      <div>
        <div>{doctor?.fullName}</div>
        <div>{doctor?.education.map((edu) => edu).join(", ")}</div>
        <div>{}</div>
        <div>{}</div>
      </div>
    </div>
  );
};

export default doctorDetail;
