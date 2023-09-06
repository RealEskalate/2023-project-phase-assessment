import React from "react";
import Image from "next/image";

const Header = () => {
  return (
    <div>
      <Image
        className="relative overflow-hidden mt-5"
        alt="background"
        src="/frame.svg"
        width={200}
        height={200}
      ></Image>
      <div className="flex items-center absolute top-[10px] right-[10px] pt-4">
        <Image
          alt="profile"
          src="/joni.svg"
          width={50}
          height={50}
          className="pl-2"
        ></Image>
        <p className="pl-2">Jonathan Alemayehu</p>
        <Image
          alt="profile"
          src="/arrow-ios-down.svg"
          width={20}
          height={20}
          className="pl-2"
        ></Image>
      </div>
    </div>
  );
};

export default Header;
