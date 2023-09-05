"use client";
import Card from "@/components/Card";
import { useGetAllDoctorsMutation } from "@/store/features/doctor-api";
import Image from "next/image";
import Link from "next/link";
import { useState } from "react";

export default function Home() {
  const [page, setPage] = useState<any>(1);
  const [find, setFind] = useState<any>("");

  const [endPoint, { data, isLoading, isError, isSuccess, error }] =
    useGetAllDoctorsMutation({ page, find });
  const handleNextPage = () => {
    setPage((page) => page + 1);
    endPoint()
  };

  const handlePreviousPage = () => {
    setPage((page) => Math.max(page - 1, 1));
    endPoint()
  };
  let content;
  if (isLoading){
    content = <p>loading</p>
  }
  else if (isError){
    content = <p>error</p>
  }
  else if (isSuccess){
    content = {data.map((detail)=> (<Link key={detail._id} href=`/doctors/${detail._id}`><Card fullName={detail.fullName}) speciality={detail.speciality} 
    institutionID_list={detail.institutionID_list}
    photo={photo}/></Link>)}
  }
  if
  return (
    <main className="">
      <input
        type={"text"}
        value={find}
        onChange={(e) => {setFind(e.target.value);setPage(1)}}
      />
      {content}
      <button onClick={handlePreviousPage}>Previous Page</button>
        <button onClick={handleNextPage}>Next Page</button>
    </main>
  );
}
