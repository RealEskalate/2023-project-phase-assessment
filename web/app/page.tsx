"use client";
import Card from "@/components/card/page";
import Search from "@/components/search/page";
import { useGetDoctorsQuery } from "@/store/feature/doctor/doctors-api";
import Link from "next/link";

export default function Home() {
  const { data: doctors, error, isLoading } = useGetDoctorsQuery();
  if (isLoading) {
    return <p className="text-3xl font-bold"> Loading</p>;
  }

  return (
    <>
      <Search />
      <div className=" m-5  w-10/12 mx-auto  flex justify-around  flex-wrap ">
        {doctors?.data.map((doctor) => (
          <Link
            href={`/doctor/${doctor._id}`}
            key={doctor._id}
            className=" md:w-[22%] my-5 cursor-pointer "
          >
            <Card doctorItem={doctor} />
          </Link>
        ))}
      </div>
    </>
  );
}
