"use client";

import React from "react";
import { useParams } from "next/navigation";
import { useGetSingleDoctorQuery } from "@/store/features/doctors/doctorsApi";
import Image from "next/image";

const page = () => {
  const { id } = useParams();
  const {
    data: doctor,
    isLoading,
    isError,
    error,
  } = useGetSingleDoctorQuery(id);
  const institutionNames = doctor?.institutionID_list.map(
    (institution: any) => institution.institutionName
  );
  const educationNames = doctor?.education.map(
    (institution: any) => institution.institutionName
  );

  console.log(doctor, institutionNames);

  if (isLoading) {
    return (
      <div className="text-4xl font-bold w-full text-center">Loading...</div>
    );
  } else if (isError) {
    return (
      <div className="text-4xl font-bold w-full text-center">
        {(error as any).data?.message}
      </div>
    );
  }

  return (
    <div>
      <div className="mx-20">
        <Image src={"../singleDoctor/background.svg"} alt={"random background"} width={700} height={200} className="w-full rounded-xl z-0"/>
        {/* <div className="w-full rounded-xl h-56 bg-blue-100"></div> */}
        <Image
          src={doctor.photo}
          alt={""}
          width={100}
          height={100}
          className="-mt-16 w-32 h-32 border-4 border-indigo-500 mx-auto rounded-full object-cover z-20"
        />
      </div>
      <div className="ml-32 w-1/2">
        <div className="mt-6 ">
          <div className="flex justify-between">
            <div>
              <h1 className="text-3xl font-bold">{doctor.fullName}</h1>
              <p className="pt-2 font-extralight text-gray-500">
                {doctor.speciality[0].name}
              </p>
            </div>
            <div className="flex flex-col justify-end items-end space-y-1">
              <div className="text-gray-500 text-xs">
                Addis Ababa University
              </div>
              {/* <div className="text-gray-500 text-xs">{educationNames.join(' | ')}</div> */}
              <div className="text-gray-500 text-sm">
                {institutionNames.join(" | ")}
              </div>
            </div>
          </div>
        </div>
        <div className="mt-16">
          <h1 className="text-lg font-bold">About</h1>
          <p className="mt-2 text-sm text-gray-500">
            Lorem ipsum dolor sit amet consectetur adipisicing elit. Veniam
            ullam velit iusto, fuga accusantium, sapiente fugit odit commodi
            cumque saepe consequatur placeat sint facilis. Suscipit mollitia
            esse est ad hic! Lorem ipsum dolor sit amet consectetur, adipisicing
            elit. Maiores dolor possimus quod neque temporibus eius! Cupiditate
            velit sapiente at modi optio recusandae, nesciunt ad sunt cum ea
            repellat repellendus reiciendis.
          </p>
        </div>
        <div className="mt-16">
          <h1 className="text-lg font-bold">Education</h1>
          <div className="mt-2 text-sm">
            <div className="mt-5 flex flex-col space-y-5">
              <div className="w-full flex justify-between">
                <div className="">
                  <h1 className="font-bold">Addis Ababa University</h1>
                  <p className="text-gray-500">Bsc. in Medicine</p>
                </div>
                <p className="text-gray-500">2003 - 2007</p>
              </div>
              <div className="w-full flex justify-between">
                <div className="">
                  <h1 className="font-bold">Addis Ababa University</h1>
                  <p className="text-gray-500">Bsc. in Medicine</p>
                </div>
                <p className="text-gray-500">2003 - 2007</p>
              </div>

              {doctor?.education?.map((edu: any) => (
                <div className="w-full flex justify-between">
                  <div className="">
                    <h1 className="font-bold">{edu.institutionName}</h1>
                    <p className="text-gray-500">{edu.type} in Medicine</p>
                  </div>
                  <p className="text-gray-500">
                    {edu.startDate} - {edu.endDate}
                  </p>
                </div>
              ))}
            </div>
          </div>
        </div>
        <div className="mt-16">
          <h1 className="text-lg font-bold">Contact Info</h1>
          <div className="mt-2 text-sm">
            <div className="mt-12 flex flex-col space-y-12">
              <div className="flex items-start justify-start space-x-4">
                <Image
                  src={"../singleDoctor/phone.svg"}
                  alt={"facebook"}
                  width={15}
                  height={15}
                />
                <div className="flex flex-col space-y-4">
                    <h1 className="font-bold text-indigo-500">Phone Number</h1>
                    <p>+251987654321</p>
                </div>
              </div>
              <div className="flex items-start justify-start space-x-4">
                <Image
                  src={"../singleDoctor/email.svg"}
                  alt={"facebook"}
                  width={15}
                  height={15}
                />
                <div className="flex flex-col space-y-4">
                    <h1 className="font-bold text-indigo-500">Email</h1>
                    <p>pauldessie@gmail.com</p>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default page;
