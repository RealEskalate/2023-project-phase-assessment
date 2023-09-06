"use client";

import React from "react";
import { useRouter } from "next/navigation";

interface doctorCardProps {
  id: string;
  photoUrl: string;
  name: string;
  speciality: string;
  hospital: string;
}

const DoctorCard: React.FC<doctorCardProps> = ({
  id,
  name,
  photoUrl,
  speciality,
  hospital,
}) => {
  const router = useRouter();

  const handleCardClick = (id: string) => {
    router.push(`/single-doctor/${id}`);
  };

  return (
    <div
      className="bg-white rounded-lg shadow-2xl p-4 mb-4 w-50 h-50 flex flex-col gap-3 justify-center items-center mt-24 cursor-pointer"
      onClick={() => handleCardClick(id)}
    >
      <div className="flex justify-center items-center mb-4">
        <img src={photoUrl} alt={name} className="rounded-full w-20 h-20 border-4 border-sub-primary" />
      </div>
      <h2 className="text-xl font-semibold mb-2">{name}</h2>
      <div className="bg-sub-primary text-white rounded-full inline-block py-1 px-4 mb-2">
        {speciality}
      </div>
      <p className="text-gray-700">{hospital}</p>
    </div>
  );
};

export default DoctorCard;
