"use client";
import { useGetDoctorsWithPaginationMutation } from "@/utils/redux/services/doctorApi";
import classNames from "classnames";
import React, { useEffect } from "react";

export default function Pagination({
  page,
  setPage,
}: {
  page: number;
  setPage: React.Dispatch<React.SetStateAction<number>>;
}) {
  const [getDoctorsWithPagination, { isLoading, isSuccess }] =
    useGetDoctorsWithPaginationMutation();

  useEffect(() => {
    getDoctorsWithPagination({ page, size: 16 });
  }, [page]);

  const handlePagination = (val: number) => {
    setPage(val);
    window.scrollTo({ top: 0, left: 0, behavior: "smooth" });
  };
  return (
    <div className="w-fit mx-auto my-3 flex items-center">
      <button
        onClick={(_) => setPage(page - 1)}
        disabled={page === 1}
        className=""
      >
        <svg
          width="14"
          height="24"
          viewBox="0 0 14 24"
          fill="none"
          xmlns="http://www.w3.org/2000/svg"
        >
          <path
            d="M0.897593 10.9393C0.311806 11.5251 0.311806 12.4749 0.897593 13.0607L10.4435 22.6066C11.0293 23.1924 11.9791 23.1924 12.5649 22.6066C13.1506 22.0208 13.1506 21.0711 12.5649 20.4853L4.07957 12L12.5649 3.51472C13.1506 2.92893 13.1506 1.97919 12.5649 1.3934C11.9791 0.807611 11.0293 0.807611 10.4435 1.3934L0.897593 10.9393ZM8.04102 10.5H1.95825V13.5H8.04102V10.5Z"
            fill="#6C63FF"
          />
        </svg>
      </button>
      {new Array(Math.ceil(4)).fill(0).map((_, index) => (
        <button
          key={index}
          onClick={() => handlePagination(index + 1)}
          className={classNames("mx-2 w-8 h-8 rounded", {
            "bg-primary text-white": page === index + 1,
          })}
          disabled={page === index + 1}
        >
          {index + 1}
        </button>
      ))}

      <button
        onClick={() => setPage(page + 1)}
        disabled={page === 4}
        className=""
      >
        <svg
          width="14"
          height="24"
          viewBox="0 0 14 24"
          fill="none"
          xmlns="http://www.w3.org/2000/svg"
        >
          <path
            d="M13.1019 13.0607C13.6877 12.4749 13.6877 11.5251 13.1019 10.9393L3.55598 1.3934C2.97019 0.807611 2.02044 0.807611 1.43466 1.3934C0.848871 1.97919 0.848871 2.92893 1.43466 3.51472L9.91994 12L1.43466 20.4853C0.848871 21.0711 0.848871 22.0208 1.43466 22.6066C2.02044 23.1924 2.97019 23.1924 3.55598 22.6066L13.1019 13.0607ZM5.9585 13.5H12.0413V10.5H5.9585V13.5Z"
            fill="#6C63FF"
          />
        </svg>
      </button>
    </div>
  );
}
