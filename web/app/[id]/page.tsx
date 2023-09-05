"use client";
import Image from "next/image";
import React from "react";
import { MdEmail } from "react-icons/md";
import { IoIosArrowBack } from "react-icons/io";
import { BsFillTelephoneFill } from "react-icons/bs";
import { useGetDoctorByIdQuery } from "@/lib/redux/apiSlice";
import { Doctor } from "@/lib/types";
import { useRouter } from "next/navigation";
import { Pulsar } from "@uiball/loaders";

const DoctorProfile = ({ params }: { params: { id: string } }) => {
  const { data, isLoading, error } = useGetDoctorByIdQuery(params.id);
  const router = useRouter();
  const doctor: Doctor = data;

  if (isLoading) {
    return (
      <div className="w-full h-96 flex justify-center items-center">
        <Pulsar size={35} color="#231F20" />
      </div>
    );
  }

  return (
    <div className="relative px-20 flex flex-col items-center mb-36">
      {/* image container */}
      <span
        className="flex gap-5 items-center self-start hover:text-blue-400 cursor-pointer transition-all ease-linear"
        onClick={() => router.replace("/")}
      >
        <IoIosArrowBack />
        <span>Go Back</span>
      </span>
      <div className="relative overflow-hidden w-full h-[288px] rounded-xl mt-28">
        <Image
          src={"/cover.png"}
          layout="fill" // required
          objectFit="cover" // change to suit your needs
          alt="logo"
          className="center"
        />
      </div>
      {/* profile pic */}
      <div className="relative">
        <div className="relative h-[227px] w-[227px] bg-grayMedium rounded-full overflow-hidden  border-4 border-subPrimary -top-28">
          <Image
            src={doctor.photo}
            layout="fill" // required
            objectFit="cover" // change to suit your needs
            alt="logo"
            className="center"
          />
        </div>
      </div>
      <div className="xl:w-1/2 w-full flex flex-col md:self-start self-center  ">
        {/* full name and education*/}
        <div className="flex justify-center items-center md:justify-between md:items-end flex-col md:flex-row">
          <span className="text-[32px] font-semibold">{doctor.fullName}</span>
          <span className="text-[#686868]">
            {doctor.education[0] || "Addis Ababa University"}
          </span>
        </div>

        <div className="flex justify-center md:justify-between items-center md:items-end flex-col md:flex-row ">
          <span className="text-[21px] font-light">
            {doctor.speciality[0].name}
          </span>
          <span className="text-[#686868] text[20px]">
            {doctor.mainInstitution.institutionName ||
              "Washington Medical Center"}
          </span>
        </div>
        <div className="flex justify-between mt-24 flex-col">
          <span className="text-[18px] font-bold">About</span>
          <p className="text-black/[0.81] mt-6">
            {doctor.summary ||
              `Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis
            pellentesque purus sit amet mi aliquam, id dictum augue vulputate.
            Pellentesque porta, ligula non pulvinar sollicitudin, dolor nunc
            molestie dui, sit amet volutpat eros nibh vitae magna. Nullam
            tempor, purus nec rutrum varius, arcu massa scelerisque diam, nec
            vestibulum diam neque a massa. Mauris tempor odio in ornare cursus.
            Maecenas in ultricies sapien. Suspendisse dolor turpis, pretium
            vitae lacus eget, condimentum aliquam diam.`}
          </p>
        </div>
        <div className="flex justify-between flex-col mt-16 gap-9">
          <span className="text-[18px] font-bold mb-6">Education</span>

          <div className="w-full">
            <div className="flex flex-col">
              <div className="w-full flex justify-between items-end">
                <span className="text-[20px] font-medium">
                  Addis Ababa University
                </span>
                <span className="text-[19px] font-light text-[#8C8C8C]">
                  2003 - 2007
                </span>
              </div>
              <span className="text-[18px] text-black/[0.71]">
                B. Sc Medicine
              </span>
            </div>
          </div>
          <div className="w-full">
            <div className="flex flex-col">
              <div className="w-full flex justify-between items-end">
                <span className="text-[20px] font-medium">
                  Addis Ababa University
                </span>
                <span className="text-[19px] font-light text-[#8C8C8C]">
                  2003 - 2007
                </span>
              </div>
              <span className="text-[18px] text-black/[0.71]">
                B. Sc Medicine
              </span>
            </div>
          </div>
        </div>
        <div className="flex justify-between flex-col mt-16">
          <span className="text-[18px] font-bold mb-6 ">Contact info</span>
          <div className="flex flex-col gap-9">
            <div className="flex gap-5 items-start">
              <span>
                <BsFillTelephoneFill />
              </span>
              <div>
                <span className="font-bold text-subPrimary flex gap-5 items-center">
                  Phone Number:
                </span>
                <span className="mt-3 text-sm text-[#484848]">
                  {(doctor?.phoneNumbers && doctor?.phoneNumbers[0]) ||
                    "+25111763498"}
                </span>
              </div>
            </div>
            <div className="flex gap-5 items-start">
              <span>
                <MdEmail />
              </span>
              <div>
                <span className="font-bold text-subPrimary flex gap-5 items-center">
                  Email:
                </span>
                <span className="mt-3 text-sm text-[#484848]">
                  {doctor?.emails[0] || "fasiltefera@stpaul.com"}
                </span>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default DoctorProfile;
