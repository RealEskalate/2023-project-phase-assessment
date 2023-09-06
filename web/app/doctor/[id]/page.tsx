"use client";
import React from "react";
import { useGetDoctorByIdQuery } from "@/lib/redux/features/doctor";
import { useParams } from "next/navigation";
import Header from "@/components/Header";
import Footer from "@/components/Footer";

const page = () => {
  const params = useParams();
  const id: any = params.id;
  const { data, isLoading, error } = useGetDoctorByIdQuery(id);

  if (isLoading) {
    <div className="flex items-center justify-center h-screen">
      <div className="animate-spin rounded-full h-16 w-16 border-t-4 border-red-500 border-solid"></div>
    </div>;
  }
  return (
    <div>
      <Header />
      <img src="/Group 8823.png" alt="" className="ml-24 mt-10" />
      <img
        src={data?.photo}
        alt=""
        className="w-28 rounded-full mx-auto -mt-16 border-4 border-primary object-cover max-h-28 border-blue-500 shadow-lg z-10"
      />
      <div className="m-24 mr-96">
        <div className="flex justify-between items-center">
          <div className="flex flex-col">
            <p className="text-2xl font-extrabold">{data?.fullName}</p>
            <p className="font-light">Internal Medicine</p>
          </div>
          <div className="flex flex-col">
            <p className="font-light text-md">Addis Ababa University</p>
            <p className="font-normal text-lg">Washington Medical Center</p>
          </div>
        </div>

        <p className="text-lg font-extrabold pt-16">About</p>
        <p className="w-[60%]">
          Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis
          pellentesque purus sit amet mi aliquam, id dictum augue vulputate.
          Pellentesque porta, ligula non pulvinar sollicitudin, dolor nunc
          molestie dui, sit amet volutpat eros nibh vitae magna. Nullam tempor,
          purus nec rutrum varius, arcu massa scelerisque diam, nec vestibulum
          diam neque a massa. Mauris tempor odio in ornare cursus. Maecenas in
          ultricies sapien. Suspendisse dolor turpis, pretium vitae lacus eget,
          condimentum aliquam diam.
        </p>
        <p className="text-lg font-extrabold pt-16">Education</p>
        <div className="flex justify-between items-center">
          <div className="flex flex-col">
            <p>Addis Ababa University</p>
            <p>B. Sc Medicine</p>
          </div>
          <div className="flex flex-col">
            <p>2003 - 2007</p>
          </div>
        </div>
        <div className="flex justify-between items-center pt-5">
          <div className="flex flex-col">
            <p>Harvard University</p>
            <p>M. Sc Internal Medicine</p>
          </div>
          <div className="flex flex-col">
            <p>2007 - 2011</p>
          </div>
        </div>
        <p className="text-lg font-extrabold pt-16">Contact Info</p>
        <p className="text-lg font-bold pt-5 text-[#7879F1]">Phone Number</p>
        <p className="font-light">+25111763498</p>
        <p className="text-lg font-bold pt-5 text-[#7879F1]">Email</p>
        <p className="font-light">fasiltefera@stpaul.com</p>
      </div>
      <Footer />
    </div>
  );
};

export default page;
