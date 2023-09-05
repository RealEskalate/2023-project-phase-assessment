"use client";
import Image from "next/image";
import React from "react";
import { useParams, usePathname } from "next/navigation";
import { useGetSingleDoctorQuery } from "@/store/feature/doctor-profile/doctor-profile";

const DetailPage = () => {
  const params = useParams();
  const id = params.id;
  const {
    data: doctoritem,
    error,
    isLoading,
  } = useGetSingleDoctorQuery(id as string);
  if (doctoritem) {
    console.log(doctoritem);
  }
  return (
    <div className="p-5 w-10/12 mx-auto">
      <div>
        <Image
          src={"/bg.svg"}
          width={1}
          height={5}
          alt="link arrow image"
          className="w-full h-[20rem] "
        />
        {/* bgimage here */}
      </div>
      <div className="flex justify-center -my-20 items-center">
        <Image
          src={doctoritem?.photo}
          width={1}
          height={5}
          alt="link arrow image"
          className="w-auto h-[13rem]  border-4  border-primary  rounded-full "
        />
      </div>

      <div className="flex w-8/12 justify-between items-center my-24">
        <div>
          <p className="font-bold text-2xl"> {doctoritem?.fullName} </p>
          <p className="text-lg">Internal Medicine</p>
        </div>
        <div>
          <p className="text-end">Addis Ababa University</p>
          <p className="text-end">Washington Medical Center</p>
        </div>
      </div>

      <div className="my-10">
        <p className="text-xl font-bold">About</p>
        <p className="w-9/12 text-justify">{doctoritem?.summary}</p>
      </div>

      <div className="w-9/12 ">
        <p className="font-bold text-xl ">Education</p>

        <div className="flex justify-between  ">
          <p className="text-lg font-bold my-2">Addis Ababa Univeristy </p>
          <span> 2003 - 3007</span>
        </div>
        <p>B.Sc Medicine</p>
      </div>

      {/* contact info */}
      <div className="my-10">
        <p className="text-xl font-bold">Contact Info</p>

        <div className="py-5">
          <p className="text-lg text-primary font-bold">Phone Number: </p>
          <span>+251234567896</span>
        </div>
        <div className="py-5">
          <p className="text-lg text-primary font-bold">Email: </p>
          <span>dawit.andargachew.asmare@gmail.com</span>
        </div>
      </div>
    </div>
  );
};

export default DetailPage;
