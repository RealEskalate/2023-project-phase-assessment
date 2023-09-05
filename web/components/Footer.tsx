import React from "react";
import { IoIosArrowForward } from "react-icons/io";
import {
  BiLogoFacebookCircle,
  BiLogoTwitter,
  BiLogoInstagram,
  BiLogoLinkedin,
} from "react-icons/bi";

const Footer = () => {
  return (
    <div className="bg-subPrimary text-background flex flex-col sm:flex-row items-center gap-8 justify-center lg:justify-between  pr-10 lg:pr-24 pt-16 flex-wrap">
      <div className="sm:pl-24">
        <span className="text-3xl font-bold">HakimHub</span>
      </div>
      <div className="flex flex-col sm:flex-row gap-16">
        <div className="flex gap-3 text-background flex-col">
          <h1 className="font-bold">Get Connected</h1>
          <span className="font-light flex items-center gap-2">
            <span className="text-sm">
              <IoIosArrowForward />
            </span>
            For Physicians
          </span>
          <span className="font-light flex items-center gap-2">
            <span>
              <IoIosArrowForward />
            </span>
            For Hospitals
          </span>
        </div>
        <div className="flex gap-3 text-background flex-col">
          <h1 className="font-bold">Actions</h1>
          <span className="font-light flex items-center gap-2">
            <span className="text-sm">
              <IoIosArrowForward />
            </span>
            Find a doctor
          </span>
          <span className="font-light flex items-center gap-2">
            <span>
              <IoIosArrowForward />
            </span>
            Find a hospital
          </span>
        </div>
        <div className="flex gap-3 text-background flex-col">
          <h1 className="font-bold">Company</h1>
          <span className="font-light flex items-center gap-2">
            <span className="text-sm">
              <IoIosArrowForward />
            </span>
            About us
          </span>
          <span className="font-light flex items-center gap-2">
            <span>
              <IoIosArrowForward />
            </span>
            Career
          </span>
          <span className="font-light flex items-center gap-2">
            <span>
              <IoIosArrowForward />
            </span>
            Join our team
          </span>
        </div>
      </div>
      <hr className=" w-full mt-14" />
      {/* socials and policy */}
      <div className="w-full flex flex-col sm:flex-row sm:justify-between justify-center my-5 sm:pl-24 gap-8 sm:gap-0 items-center">
        <div className="font-semibold flex gap-24">
          <span>Privacy Policy</span>
          <span>Terms of Use</span>
        </div>
        {/* socials */}
        <div
          className="flex text-xl gap-12
        "
        >
          <BiLogoFacebookCircle />
          <BiLogoLinkedin />
          <BiLogoInstagram />
          <BiLogoTwitter />
        </div>
      </div>
    </div>
  );
};

export default Footer;
