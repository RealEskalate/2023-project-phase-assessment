import Image from "next/image";
import React from "react";

interface Props {
  doctorImage: string;
}

export default function DoctorImageCard({ doctorImage }: Props) {
  console.log(doctorImage);
  return (
    <div className=" w-full px-20 mb-20">
      <div className=" rounded-lg relative flex flex-col items-center">
        <Image
          className="w-full h-64 object-cover rounded-xl"
          src="/images/aa.png"
          alt=""
          width={1100}
          height={500}
        />
        <div className=" w-40 h-40 absolute bottom-[-30%]">
          <img
            className="w-full h-full rounded-full border-[3px] border-[#6C63FF]"
            src={doctorImage}
            alt=""
            width={2000}
            height={2000}
          />
        </div>
      </div>
    </div>
  );
}
