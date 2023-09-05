import { Doctor } from "@/lib/types";
import Image from "next/image";
import Link from "next/link";
import React from "react";

const DoctorCard = ({ doctor }: { doctor: Doctor }) => {
  console.log(doctor);
  return (
    <Link
      href={`/${doctor._id}`}
      className="h-[258px] w-[308px] flex flex-col rounded-3xl shadow-[0px_22px_60px_0px_rgba(15,_14,_35,_0.06)] items-center px-3 relative mt-8	"
    >
      {/* image container */}
      <div className="relative h-[90px] w-[90px] bg-grayMedium rounded-full overflow-hidden  border-4 border-subPrimary -top-10">
        <Image
          src={doctor.photo}
          layout="fill" // required
          objectFit="cover" // change to suit your needs
          alt="logo"
          className="center"
        />
      </div>
      <h1 className="text-lg font-semibold mt-[10px]">{doctor.fullName}</h1>
      <span className="rounded-3xl bg-subPrimary px-2 py-2 text-sm font-light text-[#DDDCEF] my-[9px]">
        {doctor?.speciality[0]?.name}
      </span>
      <p className="text-center text-sm text-[#686868] mt-[15px]">
        {doctor.mainInstitution.institutionName}
      </p>
    </Link>
  );
};

export default DoctorCard;
