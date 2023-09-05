"use client";
import AllDoctors from "@/components/AllDoctors";
import SingleDoctor from "@/components/SingleDoctor";
import { useGetDoctorsByKeywordMutation } from "@/store/features/doctors/doctors-api";
import Image from "next/image";
import { useState, useEffect } from "react";

export default function Home() {
  const [isSearching, setIsSearching] = useState<boolean>(false);
  const [getDoctorsByKeyword, { isLoading, data, isError, isSuccess, error }] =
    useGetDoctorsByKeywordMutation();
  const [filter, setFilter] = useState("");
  useEffect(() => {
    if (filter) {
      setIsSearching(true);
    } else {
      setIsSearching(false);
    }
    getDoctorsByKeyword(filter);
  }, [filter]);

  return (
    <main>
      <div>
        <form className="relative mx-56 my-8">
          <input
            type="text"
            className="border w-full h-14 rounded-full p-5 text-lg font-poppins"
            placeholder="name"
            value={filter}
            onChange={(e) => {
              setFilter(e.target.value);
            }}
          />
          <button className="absolute top-4 right-5">
            <Image
              src={"/images/search-icon.png"}
              width={25}
              height={25}
              alt="profile"
            />
          </button>
        </form>
        {!isSearching && <AllDoctors />}
        {isSearching && isSuccess && (
          <div className="min-h-32">
            {data.data.map((doc: any) => (
              <SingleDoctor doctor={doc} />
            ))}
          </div>
        )}
      </div>
    </main>
  );
}
