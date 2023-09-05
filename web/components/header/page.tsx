import Image from "next/image";
import Link from "next/link";
import React from "react";

const Header = () => {
  return (
    <div className="flex justify-between  m-2  py-4 px-2">
      <Link href={"/"} className="w-fit h-fit">
        <Image
          src={"/logo.svg"}
          width={1}
          height={2}
          className="w-[10rem] md:w-[20rem] h-auto"
          alt="logo image"
        />
      </Link>

      <div className="flex justify-center md:gap-3 items-center">
        <Image
          src={"/person.svg"}
          width={100}
          height={200}
          className="w-8 h-8 md:w-12 md:h-12"
          alt="person image"
        />
        <span className="hidden md:block text-sm md:text-base">
          {" "}
          Dawit Andargachew
        </span>
        <Image
          src={"/arrow-down.svg"}
          width={100}
          height={200}
          className="w-4 h-4  md:w-8 md:h-8"
          alt="arrow down icon"
        />
      </div>
    </div>
  );
};

export default Header;
