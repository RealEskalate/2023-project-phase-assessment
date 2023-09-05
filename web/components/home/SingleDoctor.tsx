import { Doctor } from "@/types/Doctor";
import Image from "next/image";
import Link from "next/link";
import React from "react";

const SingleDoctor: React.FC<Doctor> = ( {_id, photo, fullName, speciality, institutionID_list} ) => {

    const institutionNames = institutionID_list.map((institution: any) => institution.institutionName)

  return (
    <Link href={`/doctors/${_id}`} className="mt-20 shadow-lg bg-white rounded-xl">
      <div className="flex flex-col items-center">
        <div className="-mt-12 w-24 h-24 rounded-full">
          <Image
            src={photo}
            alt={`${fullName}'s Image`}
            width={24}
            height={24}
            className="w-24 h-24 rounded-full object-cover border-4 border-indigo-500"
          />
        </div>
        <div className="my-3 text-xl font-bold">{fullName}</div>
        <div className="px-3 rounded-full bg-indigo-500 text-white font-extralight">{speciality[0].name}</div>
        <div className="my-6 text-gray-500 text-sm">{institutionNames.join(' | ')}</div>
      </div>
    </Link>
  );
};

export default SingleDoctor;
