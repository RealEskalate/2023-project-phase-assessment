import Image from "next/image";
import React from "react";

const NavBar = () => {
  return (
    <div className="mt-4 w-10/12 mx-auto flex justify-between">
      <Image src={"./layout/Logo.svg"} alt={""} width={250} height={100} />
      <div className="flex space-x-4 items-center">
        <Image src={"./layout/pfp.svg"} alt={""} width={50} height={50} />
        <p>Jonathan Alemayehu</p>
        <Image src={"./layout/dropdown.svg"} alt={""} width={20} height={20} />
      </div>
    </div>
  );
};

export default NavBar;
