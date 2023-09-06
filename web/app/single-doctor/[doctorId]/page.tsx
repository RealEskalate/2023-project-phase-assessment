"use client";

import React from "react";
import { useGetSingleDoctorQuery } from "@/store/features/doctor/doctor-api";
import Loading from "@/components/Loading";
import {BsFillTelephoneFill} from 'react-icons/bs'
import {HiOutlineMail} from 'react-icons//hi'


const doctor = {
  image:
    "https://res.cloudinary.com/hakimhub/image/upload/v1656314302/POP_DATA_DOC/Addis_Cardiac_Hospital_0.jpg",
  name: "Tesfaye Bekele",
  speciality: "Orthopedic",
  uni: "Addis Ababa University",
  hosp: "Yekatit 12",
  uni_1: "Addis Ababa University",
  uni_2: "Howard medical school",
  date_1: "2003-2007",
  date_2: "2007-2011",
  tel: "0900026618",
  email: "admas@gmail.com",
};

interface props {
  params: {
    doctorId: string;
  };
}

const SingleDoctorPage: React.FC<props> = ({ params }) => {
  console.log(">>", params);
  const { data, isLoading, isError } = useGetSingleDoctorQuery(params.doctorId);

  if (isLoading) {
    return (
      <div>
        <Loading />
      </div>
    );
  }

  if (isError || !data) {
    return <div>Error fetching data.</div>;
  }

  const doctor = data;

  return (
    <section>
      <div className="relative w-100 mx-10 mt-12">
        <img src="/images/heart-machine.png" alt="Stethescope" />
      </div>
      <div className="absolute left-1/2 transform -translate-x-1/2 -translate-y-1/2">
        <img className="rounded-full border-4 border-sub-primary w-40 h-40" src={doctor.photo} alt="Doctor photo" />
      </div>

      <div className="w-1/2 mx-16 mt-24">
        <div className="flex flex-col justify-between">
          <div className="flex mb-48 justify-between">
            <div>
              <h2 className="font-bold text-2xl">{doctor.fullName}</h2>
              <p className="text-gray-400">{doctor.speciality[0].name}</p>
            </div>
            <div className="text-gray-400 self-end">
              <p>{"Addis Ababa University"}</p>
              <p>{doctor.institutionID_list[0].institutionName}</p>
            </div>
          </div>

          <div className="flex flex-col">
            <div className="flex flex-col">
              <div className="flex justify-between">
                <p className="font-semibold">{"Addis Ababa University"}</p>
                <p className="text-gray-400">{"2003-2007"}</p>
              </div>
              <div className="flex justify-between">
                <p className="font-semibold">{"Harvard University"}</p>
                <p className="text-gray-400">{"2007-2011"}</p>
              </div>
            </div>
          </div>

          <div className="mt-4">
            <div>
              <p className="font-semibold my-8">Contact Info</p>
              <div className="flex gap-6">
                <BsFillTelephoneFill />
                <p className="mb-2 text-sub-primary font-semibold">
                  Phone Number
                </p>
              </div>
              <p className="text-gray-400 px-8">{"+251900026618"}</p>
            </div>
            <div className="mt-4">
              <div className="flex gap-6">
                <HiOutlineMail />
                <p className="mb-2 text-sub-primary font-semibold">
                  Email
                </p>
              </div>
              <p className="text-gray-400 px-8">{"MohammedBedru@gmail.com"}</p>
            </div>
          </div>
        </div>
      </div>
    </section>
  );
};

export default SingleDoctorPage;
