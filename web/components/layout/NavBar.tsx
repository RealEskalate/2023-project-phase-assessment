import Image from "@/node_modules/next/image";
import React from "react";

const Footer = () => {
  return (
    <div className="flex justify-between p-5 m-10">
      <div className="">
        <Image
          src="/Navbar/Hakimhub.png"
          width={200}
          height={200}
          alt="hakim"
        />
      </div>
      <div className="flex">
        <Image src="/Navbar/Icon.png" width={50} height={50} alt="" />
        <h3 className="ml-5 mt-2">Jonantan Alemayehu</h3>
        <Image
          src="/Navbar/drop.png"
          width={50}
          height={50}
          alt=""
          className="ml-5"
        />
      </div>
    </div>
  );
};

export default Footer;
