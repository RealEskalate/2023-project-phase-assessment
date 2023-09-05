import { useGetDoctorsWithPageMutation } from "@/store/features/doctors/doctors-api";
import { useState, useEffect } from "react";
import { COUNT_ON_SINGLE_PAGE } from "@/store/features/doctors/doctors-api";
import Link from "next/link";
import SingleDoctor from "./SingleDoctor";

const AllDoctors = () => {
  const [getDoctorsWithPage, { isLoading, data, isError, isSuccess, error }] =
    useGetDoctorsWithPageMutation();
  const [pageNumber, setPageNumber] = useState(1);

  useEffect(() => {
    getDoctorsWithPage(pageNumber);
  }, [pageNumber])
  return (
    <div>
      {isLoading && (
        <p className="text-6xl m-32 w-screen text-center">loading...</p>
      )}
      {isSuccess && (
        <div className="flex w-full flex-wrap px-12 justify-center">
          {data.data.map((doctor: any) => <SingleDoctor doctor={doctor}/>)}
          <div className="w-full flex justify-center">
            {Array.from(
              { length: data.totalCount / COUNT_ON_SINGLE_PAGE },
              (value, index) => index + 1
            ).map((page) => {
              let classNameAdded =
                page == pageNumber
                  ? "bg-blue-400 text-white"
                  : "bg-white text-blue-400";
              return (
                <div className={`rounded h-8 w-8 text-center my-10 cursor-pointer mx-4 ${classNameAdded}`} onClick={(()=>{setPageNumber(page)})}>{page}</div>
              );
            })}
          </div>
        </div>
      )}
    </div>
  );
};

export default AllDoctors;
