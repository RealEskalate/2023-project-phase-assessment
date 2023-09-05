import { doctor } from "@/types/doctor/doctor";
import Image from "next/image";
import React from "react";

interface DoctorProp {
  doctorItem: doctor;
}

const Card = ({ doctorItem }: DoctorProp) => {
  return (
    <div className="flex gap-y-3 flex-col  py-[3rem] shadow-lg rounded-lg px-3 justify-center  items-center ">
      <Image
        src={doctorItem.photo}
        width={1}
        height={5}
        alt="link arrow image"
        className="w-32 h-32  border-4 border-primary  rounded-full "
      />
      <p className="  font-bold text-xl">{doctorItem.fullName}</p>
      {doctorItem.speciality.map((speci) => (
        <p
          className=" px-3 text-white  rounded-full bg-primary font-light"
          key={speci.name}
        >
          {speci.name}{" "}
        </p>
      ))}
      <p className="text-center  w-10/12 mx-auto">
        {doctorItem.institutionID_list.map((inst) => (
          <span> {inst.institutionName} | </span>
        ))}
      </p>
    </div>
  );
};

export default Card;
