import Image from "next/image";
import React from "react";
import { RiArrowDropDownLine } from "react-icons/ri";

const Header = () => {
  return (
    <div className="px-20 py-10 flex justify-between items-center">
      <div className="flex items-center gap-2">
        {/* logo container */}
        <div className=" w-10 h-10 rounded-full overflow-hidden relative">
          <Image
            src={"/vector.png"}
            layout="fill" // required
            objectFit="cover" // change to suit your needs
            alt="logo"
            className="center"
          />
        </div>
        <span className="text-3xl font-bold text-grayMedium ">
          Hakim
          <span className="text-[#FF7272]">Hub</span>
        </span>
      </div>
      <div>
        {/* profile section */}
        <div className="flex items-center">
          {/* profile image */}
          <div className="w-12 h-12 rounded-full overflow-hidden relative  md:mr-4">
            <Image
              src={"/profile.png"}
              layout="fill" // required
              objectFit="cover" // change to suit your needs
              alt="logo"
              className="center"
            />
          </div>
          <span className="text-lg text-grayMedium hidden  md:block ">
            Jonathan Alemayehu
          </span>
          <span className="text-4xl text-grayMedium ml-2">
            <RiArrowDropDownLine />
          </span>
        </div>
      </div>
    </div>
  );
};

export default Header;
