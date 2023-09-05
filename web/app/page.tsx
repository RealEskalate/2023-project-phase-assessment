"use client";
import { useState } from "react";
import { useGetDoctorsQuery } from "@/lib/redux/services/doctorsApi";
import { DoctorData } from "@/types";
import Card from "@/components/Card";

export default function Home() {
  const [search, setSearch] = useState("");
  const [page, setPage] = useState(1);
  const minPage = 1;
  let maxPage = 6;
  const range = [];

  if (page < minPage) setPage(minPage);
  if (page > maxPage) setPage(maxPage);

  const { data, error, isLoading } = useGetDoctorsQuery({
    keyword: search,
    from: page,
  });

  if (isLoading) return <p>Loading...</p>;
  if (error) return <p>Error has happened</p>;
  if (data) {
    maxPage = Math.ceil(data.totalCount / 16) || 1;
    for (let i = 1; i <= maxPage; i++) range.push(i);
  }

  return (
    <main className="flex min-h-screen flex-col items-center justify-between gap-12">
      <div className="flex items-center justify-center gap-10 w-full">
        <div className="relative w-9/12">
          <div className="absolute inset-y-0 right-5 flex items-center pl-3 pointer-events-none">
            <svg
              className="w-4 h-4 text-gray-500 dark:text-gray-400"
              aria-hidden="true"
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 20 20"
            >
              <path
                stroke="currentColor"
                stroke-linecap="round"
                stroke-linejoin="round"
                stroke-width="2"
                d="m19 19-4-4m0-7A7 7 0 1 1 1 8a7 7 0 0 1 14 0Z"
              />
            </svg>
          </div>
          <input
            type="search"
            id="default-search"
            className="block w-full p-4 pl-10 text-sm text-gray-900 border border-gray-300 rounded-full bg-gray-50 focus:ring-blue-500 focus:border-blue-500"
            placeholder="Name"
          />
        </div>
      </div>
      <div className="w-full grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-4">
        {data &&
          data?.data?.map((doctor: DoctorData) => (
            <Card doctor={doctor} key={doctor._id} />
          ))}
      </div>
      <div className="w-full flex items-center justify-center gap-1">
        {range.map((i) => (
          <button
            key={i}
            className={`rounded px-4 py-1 bg-white text-[#6C63FF] ${
              page == i && "!bg-[#6C63FF] !text-white"
            }`}
            onClick={() => setPage(i)}
          >
            {i}
          </button>
        ))}
      </div>
    </main>
  );
}
