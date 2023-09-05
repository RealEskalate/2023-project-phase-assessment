"use client";
import { useGetDoctorsWithPaginationMutation } from "@/utils/redux/services/doctorApi";
import { useEffect, useState } from "react";
import DoctorCard from "./DoctorCard";
import { useSelector } from "react-redux";
import { selectState } from "@/utils/redux/store";
import Pagination from "../common/Pagination";
import PageLoader from "../common/Loader";
import { useRouter } from "next/navigation";

export default function DoctorList() {
  const [page, setPage] = useState<number>(1);
  const doctors: any = useSelector(selectState);
  const router = useRouter();

  const [getDoctorsWithPagination, { isLoading, isSuccess, isError }] =
    useGetDoctorsWithPaginationMutation();

  useEffect(() => {
    getDoctorsWithPagination({ page, size: 16 }).unwrap();
  }, [page]);

  if (isError) throw new Error("Network Connectivity Error!");

  return (
    <div className="w-full h-full">
      {isLoading && <PageLoader />}
      <div className="w-full h-full grid xl:grid-cols-4 lg:grid-cols-3 sm:grid-cols-2 grid-cols-1 gap-5">
        {isSuccess &&
          doctors.map((doctor: any) => <DoctorCard doctor={doctor} />)}
      </div>
      <div>
        <div>
          <Pagination page={page} setPage={setPage} key={1} />
        </div>
      </div>
    </div>
  );
}
