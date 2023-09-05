import Image from "next/image";
import React from "react";
import FooterListItem from "./FooterListItem";

const Footer = () => {
  return (
    <div className="pt-16 bg-indigo-500 text-white">
      <div className="w-5/6">
        <div className="ml-10 flex justify-between">
          <h1 className="text-3xl font-bold">HakimHub</h1>
          <div className="flex space-x-12">
            <div className="flex flex-col space-y-4">
              <h1 className="ml-1 font-bold">Get Connected</h1>
              <FooterListItem content="For Physicians" />
              <FooterListItem content="For Hospitals" />
            </div>
            <div className="flex flex-col space-y-4">
              <h1 className="ml-1 font-bold">Actions</h1>
              <FooterListItem content="Find a doctor" />
              <FooterListItem content="Find a hospital" />
            </div>
            <div className="flex flex-col space-y-4">
              <h1 className="ml-1 font-bold">Company</h1>
              <FooterListItem content="About Us" />
              <FooterListItem content="Career" />
              <FooterListItem content="Join our team" />
            </div>
          </div>
        </div>
        <div className="mt-16 h-0.5 bg-white bg-opacity-90"></div>
        <div className="mt-4 pb-4">
          <div className="ml-10 flex justify-between">
            <div className="flex space-x-12">
              <p className="font-bold">Privacy Policy</p>
              <p className="font-bold">Terms of Use</p>
            </div>
            <div className="flex space-x-12 mr-10">
              <Image src={"./socialMedia/facebook.svg"} alt={"facebook"} width={20} height={20} />
              <Image src={"./socialMedia/LinkedIn.svg"} alt={"linkedin"} width={20} height={20} />
              <Image src={"./socialMedia/instagram.svg"} alt={"instagram"} width={20} height={20} />
              <Image src={"./socialMedia/twitter.svg"} alt={"twitter"} width={20} height={20} />
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Footer;
