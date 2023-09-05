import React from "react";
import Image from "next/image";
import Link from "next/link";

interface Props {
  id: string;
  imageurl: string;
  name: string;
  speciality: string;
  hospital: string;
}

export default function DoctorCard({
  id,
  imageurl,
  name,
  speciality,
  hospital,
}: Props) {
  console.log(id);
  return (
    <Link href={`/doctor/${id}`}>
      <div className="w-72 flex flex-col gap-3 items-center rounded-3xl shadow-doctor-card px-5 pb-5 shadow-t-none border-t border-white">
        <div>
          <img
            className="w-24 h-24 border-[3px] border-[#6C63FF] rounded-full object-cover"
            width={100}
            height={100}
            src={imageurl}
            alt=""
          />
        </div>
        <div className="text-center font-poppins px-1 font-semibold text-base">
          {name}
        </div>
        <div className="text-center text-white font-poppins px-3 py-0.5 text-base rounded-xl bg-[#6C63FF]">
          {speciality}
        </div>
        <div className="text-center font-poppins px-1 ">{hospital}</div>
      </div>
    </Link>
  );
}
