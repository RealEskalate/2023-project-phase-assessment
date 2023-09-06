"use client";
import React, { useState } from "react";
import type { NextPage } from "next";
import DoctorCardList from "./DoctorCardList";
import Header from "./Header";
import Footer from "./Footer";

const DoctorSearchFilter: NextPage = () => {
  const [searchQuery, setSearchQuery] = useState<string>("");
  const [isSearching, setIsSearching] = useState<boolean>(false);

  const handleSearchInputChange = (
    event: React.ChangeEvent<HTMLInputElement>
  ) => {
    setSearchQuery(event.target.value);
    setIsSearching(true);
    setTimeout(() => {
      setIsSearching(false);
    }, 2000)
  };

  return (
    <div>
      <div className="relative bg-white w-full h-[2071px] overflow-hidden text-left text-sm text-black font-poppins">
        <Header />

        <input
          className="absolute pl-6 top-[151px] left-[170px] rounded-[42px] box-border w-[1006px] h-[50px] border-[1px] border-solid border-gainsboro font-lg "
          placeholder="Name"
          value={searchQuery}
          onChange={handleSearchInputChange} 
        />
        <div className="absolute top-[151px] left-[194px] flex flex-row p-2.5 items-center justify-center text-xl text-lightgray"></div>
        <img
          className="absolute top-[169px] left-[1127px] w-[23px] h-[24.37px]"
          alt=""
          src="/search-icon.svg"
        />
        <img
          className="absolute h-[0.7%] w-[1.25%] top-[8.16%] right-[26.81%] bottom-[91.14%] left-[71.94%] max-w-full overflow-hidden max-h-full"
          alt=""
          src="/vector.svg"
        />
        <div className="absolute top-[163px] left-[1075px] text-lg font-semibold text-white">
          Filter
        </div>

        <DoctorCardList searchQuery={searchQuery} isSearching={isSearching} />

        <Footer />
      </div>
    </div>
  );
};

export default DoctorSearchFilter;
