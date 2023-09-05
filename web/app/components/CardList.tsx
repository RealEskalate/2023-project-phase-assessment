"use client";
import { useGetDoctorsQuery } from "@/lib/redux/slices/doctorsApi";
import CardItem from "./CardItem";
import Link from "next/link";

type Doctor = {};

const CardList = () => {
  const { data, isLoading, isError } = useGetDoctorsQuery();

  const doctors = data?.data;
  return (
    <section className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-5 container mx-auto mt-16 mb-12">
      {doctors?.map((doctor: any) => (
        <Link href={`doctor/${doctor._id}`}>
          <CardItem key={doctor._id} doctor={doctor} />
        </Link>
      ))}
    </section>
  );
};

export default CardList;
