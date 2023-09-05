import Image from "next/image";
import Frame from "@/public/assets/images/Frame.svg";
import HakimHub from "@/public/assets/images/HakimHub.svg";
import Profile from "@/public/assets/images/profile.png";
// import dropDown from "@/public/assets/images/🎨 Color.png";
import { IoIosArrowDown } from "react-icons/io";

const Navbar = () => {
  return (
    <nav className="container mx-auto">
      <div className="flex justify-between items-center py-2 px-2">
        <div className="flex items-center ml-2 space-x-2 cursor-pointer">
          <Image src={Frame} alt="Logo" className="w-30 h-25" />
          <Image src={HakimHub} alt="logo title" className="w-30 h-25" />
        </div>
        <div className="flex items-center px-3 py-2 space-x-2">
          <Image src={Profile} alt="profile" className="w-15 h-15" />
          <p className="text-[17px] font-semi text-[#5A5555]">
            Jonathan Alemayehu
          </p>
          <IoIosArrowDown size={25} color="#5A5555" />
        </div>
      </div>
    </nav>
  );
};

export default Navbar;
