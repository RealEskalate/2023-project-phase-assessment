"use client";
import {
  useGetDoctorsWithPaginationMutation,
  useSearchDoctorsMutation,
} from "@/utils/redux/services/doctorApi";
import { useEffect, useState } from "react";

export default function SearchBar() {
  const [searchQuery, setSearchQuery] = useState<string>("");

  const [searchDoctors] = useSearchDoctorsMutation();
  const [getDoctorsWithPagination] = useGetDoctorsWithPaginationMutation();

  useEffect(() => {
    if (searchQuery !== "") {
      searchDoctors(searchQuery);
    } else {
      getDoctorsWithPagination({ page: 1, size: 16 });
    }
  }, [searchQuery]);
  return (
    <div className="relative w-full  max-w-5xl mx-auto">
      <input
        type="text"
        name="search_query"
        id="search_query"
        className="w-full outline-none text-[#DFDFE2] border-2 border-[#DFDFE2] py-3 pl-10 rounded-[42px] text-base font-medium"
        placeholder="Name"
        value={searchQuery}
        onChange={(e) => setSearchQuery(e.target.value)}
      />
      <svg
        width="23"
        height="25"
        viewBox="0 0 23 25"
        fill="none"
        xmlns="http://www.w3.org/2000/svg"
        className="absolute top-1/2 right-5 transform -translate-y-1/2"
      >
        <path
          d="M22.6178 22.0602L16.9772 16.0772C19.8132 12.1665 19.5296 6.51779 16.1263 2.94136C14.2671 0.969312 11.8722 0 9.44576 0C7.01932 0 4.6244 0.969312 2.76519 2.94136C-0.921729 6.85203 -0.921729 13.2027 2.76519 17.1134C4.6244 19.0854 7.01932 20.0547 9.44576 20.0547C11.4625 20.0547 13.4793 19.3862 15.1494 18.0158L20.8216 23.9654C21.0737 24.2328 21.3888 24.3665 21.7355 24.3665C22.0506 24.3665 22.3972 24.2328 22.6493 23.9654C23.122 23.464 23.122 22.595 22.6178 22.0602ZM9.47727 17.3473C7.61805 17.3473 5.9164 16.5786 4.59289 15.2082C1.91436 12.3671 1.91436 7.72107 4.59289 4.84656C5.88489 3.47615 7.61805 2.70739 9.47727 2.70739C11.3365 2.70739 13.0381 3.47615 14.3616 4.84656C15.6852 6.21697 16.3784 8.05532 16.3784 10.0274C16.3784 11.9994 15.6536 13.8043 14.3616 15.2082C13.0696 16.612 11.305 17.3473 9.47727 17.3473Z"
          fill="#D6D1D1"
        />
      </svg>
    </div>
  );
}
