"use client";
import { useGetAllDoctorsQuery } from "@/lib/redux/services/doctorsApi";
import React, { useState } from "react";
import DoctorCard from "./DoctorCard";

export default function DoctorList() {
  const [pageno, setPage] = useState(1);
  const [searchName, setSearchName] = useState("");
  const { data, isLoading, error } = useGetAllDoctorsQuery({
    from: pageno,
    size: 16,
    keyword: searchName,
  });

  const handlePageChange = (page: number) => {
    console.log(page);
    setPage(page);
  };

  const handlePrevious = () => {
    if (pageno > 1) {
      setPage(pageno - 1);
    }
  };
  const handleNext = () => {
    if (pageno < 4) {
      setPage(pageno + 1);
    }
  };

  const totalItems = 64;
  const totalPages = Math.ceil(totalItems / 16);

  const renderPageButtons = () => {
    const pageButtons = [];
    let startPage = 1;
    let endPage = totalPages;

    if (totalPages > 4) {
      if (pageno <= 3) {
        endPage = 4;
      } else if (pageno >= totalPages - 2) {
        startPage = totalPages - 4;
      } else {
        startPage = pageno - 2;
        endPage = pageno + 2;
      }
    }
    pageButtons.push(
      <button onClick={handlePrevious}>
        <svg
          className="w-3 h-3 shrink-0"
          viewBox="0 0 14 24"
          fill="none"
          xmlns="http://www.w3.org/2000/svg"
        >
          <path
            id="Arrow 2"
            d="M0.897593 10.9393C0.311806 11.5251 0.311806 12.4749 0.897593 13.0607L10.4435 22.6066C11.0293 23.1924 11.9791 23.1924 12.5649 22.6066C13.1506 22.0208 13.1506 21.0711 12.5649 20.4853L4.07957 12L12.5649 3.51472C13.1506 2.92893 13.1506 1.97919 12.5649 1.3934C11.9791 0.807611 11.0293 0.807611 10.4435 1.3934L0.897593 10.9393ZM8.04102 10.5H1.95825V13.5H8.04102V10.5Z"
            fill="#6C63FF"
          />
        </svg>
      </button>
    );

    for (let page = startPage; page <= endPage; page++) {
      pageButtons.push(
        <button
          key={page}
          className={`px-2 py-0.5 rounded-md font-mono ${
            pageno === page
              ? "text-[#FFF] bg-[#6C63FF]"
              : "text-[#6C63FF]  border border-[#9996C7]"
          }`}
          onClick={() => handlePageChange(page)}
        >
          {page}
        </button>
      );
    }
    pageButtons.push(
      <button onClick={handleNext}>
        <svg
          className="w-3 h-3 shrink-0"
          viewBox="0 0 14 24"
          fill="none"
          xmlns="http://www.w3.org/2000/svg"
        >
          <path
            id="Arrow 2"
            d="M13.1019 13.0607C13.6877 12.4749 13.6877 11.5251 13.1019 10.9393L3.55598 1.3934C2.97019 0.807611 2.02044 0.807611 1.43466 1.3934C0.848871 1.97919 0.848871 2.92893 1.43466 3.51472L9.91994 12L1.43466 20.4853C0.848871 21.0711 0.848871 22.0208 1.43466 22.6066C2.02044 23.1924 2.97019 23.1924 3.55598 22.6066L13.1019 13.0607ZM5.9585 13.5H12.0413V10.5H5.9585V13.5Z"
            fill="#6C63FF"
          />
        </svg>
      </button>
    );

    return pageButtons;
  };
  return (
    <div className="flex flex-col gap-20 items-center">
      <div>
        <form className="flex items-center border border-[#DFDFE2] rounded-full">
          <div className="relative w-full">
            <input
              type="text"
              value={searchName}
              onChange={(e) => setSearchName(e.target.value)}
              className="px-5 py-1 w-[700px] focus:outline-none rounded-full placeholder:text-[#DCD0D0]"
              placeholder="Name"
            />
            <button
              type="button"
              className="absolute inset-y-0 right-0 flex items-center pr-3"
            >
              <svg
                className="w-4 h-4"
                viewBox="0 0 23 25"
                fill="none"
                xmlns="http://www.w3.org/2000/svg"
              >
                <path
                  id="Search Icon"
                  d="M22.6178 22.0602L16.9772 16.0772C19.8132 12.1665 19.5296 6.51779 16.1263 2.94136C14.2671 0.969312 11.8722 0 9.44576 0C7.01932 0 4.6244 0.969312 2.76519 2.94136C-0.921729 6.85203 -0.921729 13.2027 2.76519 17.1134C4.6244 19.0854 7.01932 20.0547 9.44576 20.0547C11.4625 20.0547 13.4793 19.3862 15.1494 18.0158L20.8216 23.9654C21.0737 24.2328 21.3888 24.3665 21.7355 24.3665C22.0506 24.3665 22.3972 24.2328 22.6493 23.9654C23.122 23.464 23.122 22.595 22.6178 22.0602ZM9.47727 17.3473C7.61805 17.3473 5.9164 16.5786 4.59289 15.2082C1.91436 12.3671 1.91436 7.72107 4.59289 4.84656C5.88489 3.47615 7.61805 2.70739 9.47727 2.70739C11.3365 2.70739 13.0381 3.47615 14.3616 4.84656C15.6852 6.21697 16.3784 8.05532 16.3784 10.0274C16.3784 11.9994 15.6536 13.8043 14.3616 15.2082C13.0696 16.612 11.305 17.3473 9.47727 17.3473Z"
                  fill="#D6D1D1"
                />
              </svg>
            </button>
          </div>
        </form>
      </div>
      <div className="grid grid-cols-4 gap-10">
        {data?.data.map((item) => (
          <div>
            <DoctorCard
              id={item._id}
              imageurl={item.photo}
              hospital={
                item?.institutionID_list
                  ? item.institutionID_list[0]?.institutionName
                  : ""
              }
              name={item?.fullName}
              speciality={item?.speciality ? item.speciality[0]?.name : ""}
            />
          </div>
        ))}
      </div>
      <div className="flex justify-center mb-10">
        <div className="flex gap-4">{renderPageButtons()}</div>
      </div>
    </div>
  );
}
