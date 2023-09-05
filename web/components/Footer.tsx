import React from "react";
import Image from "next/image";

const Footer = () => {
  return (
    <footer className="bg-[#6C63FF] w-full flex flex-col text-white">
      <div className="p-16 flex flex-wrap justify-between items-start">
        <h2 className="text-2xl font-bold pb-4">Hakim Hub</h2>
        <div className="flex flex-wrap gap-12 items-start">
          <div>
            <h3 className="text-bold">Get Connected</h3>
            <p className="text-sm font-light text-slate-300">
              &gt; For Physicians
            </p>
            <p className="text-sm font-light text-slate-300">
              &gt; For Hospitals
            </p>
          </div>
          <div>
            <h3 className="text-bold">Actions</h3>
            <p className="text-sm font-light text-slate-300">
              &gt; Find a doctor
            </p>
            <p className="text-sm font-light text-slate-300">
              &gt; Find a hospital
            </p>
          </div>
          <div>
            <h3 className="text-bold">Company</h3>
            <p className="text-sm font-light text-slate-300"> &gt; About us</p>
            <p className="text-sm font-light text-slate-300"> &gt; Career</p>
            <p className="text-sm font-light text-slate-300">
              &gt; Join our team
            </p>
          </div>
        </div>
      </div>
      <div className="px-12 w-11/12 flex flex-warp justify-between items-center py-4 border-t border-white">
        <div className="flex items-center gap-12">
          <p>Privacy Policy</p>
          <p>Terms of Use</p>
        </div>
        <div className="flex gap-8">
          <Image src="/Facebook.svg" alt="Facebook" height={24} width={24} />
          <Image src="/Instagram.svg" alt="Instagram" height={24} width={24} />
          <Image src="/Linkedin.svg" alt="Linkedin" height={24} width={24} />
          <Image src="/Twitter.svg" alt="Twitter" height={24} width={24} />
        </div>
      </div>
    </footer>
  );
};
export default Footer;
