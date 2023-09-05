"use client";

import DoctorsList from "@/components/DoctorsList";
import { Pagination } from "@/components/Pagination";
import { useGetDoctorsMutation, useSearchMutation } from "@/lib/redux/apiSlice";
import { Doctor } from "@/lib/types";
import Image from "next/image";
import React, { useEffect, useState } from "react";
import { BsSearch } from "react-icons/bs";
import { Pulsar } from "@uiball/loaders";

export default function Home() {
  const [getDoctors, { isLoading }] = useGetDoctorsMutation();
  const [doctors, setDoctors] = useState<Doctor[]>([]);
  const [searchValue, setSearch] = useState<string>("");
  const [search, { isLoading: searchLoading, error }] = useSearchMutation();

  useEffect(() => {
    async function fetchDoctors() {
      try {
        const data = await getDoctors({}).unwrap();
        setDoctors(data.data);
      } catch (error) {
        console.log(error);
      }
    }
    fetchDoctors();
  }, []);

  const handleChange = async (e: any) => {
    setSearch(e.target.value);
    try {
      const data = await search(e.target.value).unwrap();
      console.log("searched", data, e.target.value);
      setDoctors(data.data);
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <main className="flex flex-col justify-center items-center">
      {/* search bar */}
      <div className="w-2/3 relative mt-16">
        <input
          type="text"
          className="w-full border rounded-3xl overflow-hidden py-3 px-5 text-lightGray2 pr-7 border-[#DFDFE2]
          "
          placeholder="Name"
          value={searchValue}
          onChange={(e) => handleChange(e)}
        />
        <span className="text-2xl text-[#D6D1D1] absolute top-3 right-4">
          <BsSearch />
        </span>
      </div>
      {isLoading || searchLoading ? (
        <div className="w-full h-96 flex justify-center items-center">
          <Pulsar size={35} color="#231F20" />
        </div>
      ) : (
        <DoctorsList doctors={doctors} />
      )}
    </main>
  );
}
