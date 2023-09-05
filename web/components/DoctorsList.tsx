import { Doctor } from "@/lib/types";
import React, { useState } from "react";
import DoctorCard from "./DoctorCard";
import { Pagination } from "./Pagination";

const DoctorsList = ({ doctors }: { doctors: any }) => {
  const [page, setPage] = useState<number>(1);
  const [listPerPage, setListsPerPage] = useState(3); // Dynamic number of blogs per page
  const [paginationCount, setPaginationCount] = useState(5);

  const totalList = doctors.length; // Calculate total number of blogs

  const startIndex = (page - 1) * listPerPage;
  const endIndex = startIndex + listPerPage;
  const paginatedList = doctors.slice(startIndex, endIndex);

  console.log("here are they", doctors);
  return (
    <>
      <div className=" flex flex-wrap gap-[45px] items-center justify-center py-24">
        {paginatedList?.map((doctor: Doctor, index: number) => (
          <DoctorCard doctor={doctor} />
        ))}
      </div>
      <Pagination
        listPerPage={listPerPage}
        paginationCount={paginationCount}
        setPage={setPage}
        totalList={totalList}
        page={page}
        key={React.useId()}
      />
    </>
  );
};

export default DoctorsList;
