import Image from "next/image";
import { RiArrowDropDownLine } from "react-icons/ri";

const Header = () => {
  return (
    <div className="flex justify-between items-center px-10 py-5">
      <div className="flex gap-3 items-center">
        <Image
          src="/header-assets/hakimhub-logo.svg"
          width={39}
          height={39}
          alt="logo"
        />
        <p className="text-[#424242] font-bold text-2xl md:text-3xl">
          Hakim<span className="text-[#FF7272]">Hub</span>
        </p>
      </div>
      <div className="flex gap-3 items-center">
        <Image
          className="w-16 h-16 border border-primary rounded-full"
          src="/header-assets/fake-profile.jpg"
          width={39}
          height={39}
          alt="logo"
        />
        <p className=" hidden md:block text-[#5A5555]">Jonathan Alemayehu</p>
        <RiArrowDropDownLine className="w-10 h-10  hidden md:block" />
      </div>
    </div>
  );
};

export default Header;
