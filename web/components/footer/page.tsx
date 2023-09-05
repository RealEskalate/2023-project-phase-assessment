import { actions, company, getConnected } from "@/types/footer-vav/footerLink";
import Image from "next/image";
import Link from "next/link";
import React from "react";

const Footer = () => {
  return (
    <div className=" m-1 px-5 py-10  bg-primary text-white">
      <div className="flex justify-between">
        <div className="w-3/12  flex items-center">
          <p className="text-4xl  font-bold">HakimHUb</p>
        </div>

        {/* footer links */}
        <div className="w-6/12  py-2 mr-40   flex justify-evenly ">
          {/* get connected */}
          <div className="flex flex-col gap-y-2">
            <p className="font-bold text-xl ">Get Connected</p>
            {getConnected.map((link) => (
              <Link
                className="flex items-center"
                key={link.linkName}
                href={link.linkPath}
              >
                <Image
                  src={"footer/link-arrow.svg"}
                  width={1}
                  height={5}
                  alt="link arrow image"
                  className="w-2 h-2 mr-2 inline-block"
                />
                {link.linkName}
              </Link>
            ))}
          </div>

          {/* actions */}
          <div className="flex flex-col gap-y-2">
            <p className="font-bold text-xl ">Actions</p>
            {actions.map((link) => (
              <Link
                className="flex items-center"
                key={link.linkName}
                href={link.linkPath}
              >
                <Image
                  src={"footer/link-arrow.svg"}
                  width={1}
                  height={5}
                  alt="link arrow image"
                  className="w-2 h-2 mr-2 inline-block"
                />

                {link.linkName}
              </Link>
            ))}
          </div>

          {/* company */}
          <div className="flex flex-col gap-y-2">
            <p className="font-bold text-xl ">Company</p>
            {company.map((link) => (
              <Link
                className="flex items-center"
                key={link.linkName}
                href={link.linkPath}
              >
                <Image
                  src={"footer/link-arrow.svg"}
                  width={1}
                  height={5}
                  alt="link arrow image"
                  className="w-2 h-2 mr-2 inline-block"
                />
                {link.linkName}
              </Link>
            ))}
          </div>
        </div>
      </div>

      <div className="border-t-2 flex justify-between w-10/12   mt-10 py-4">
        <div className=" w-4/12 flex justify-evenly">
          <p className="text-xl font-bold">Privacy Policy</p>
          <p className="text-xl font-bold">Terms of User</p>
        </div>

        <div className="flex justify-evenly w-4/12">
          <Image
            width={1}
            height={1}
            src={"/footer/facebook.svg"}
            alt="facebook logo "
            className="w-8 h-8"
          />
          <Image
            width={1}
            height={1}
            src={"/footer/linkedin.svg"}
            alt="facebook logo "
            className="w-8 h-8"
          />
          <Image
            width={1}
            height={1}
            src={"/footer/instagram.svg"}
            alt="facebook logo "
            className="w-8 h-8"
          />
          <Image
            width={1}
            height={1}
            src={"/footer/twitter.svg"}
            alt="facebook logo "
            className="w-8 h-8"
          />
        </div>
      </div>
    </div>
  );
};

export default Footer;
