import { FaLinkedinIn } from "react-icons/fa";
import { BsFacebook } from "react-icons/bs";
import { AiOutlineInstagram } from "react-icons/ai";
import { BiLogoTwitter, BiChevronRight } from "react-icons/bi";
import { footerLinks } from "@/data/footer/footer-data";

const Footer = () => {
  return (
    <div className="bg-[#7879F1] flex flex-col gap-9 text-white pl-5 pr-24 pt-10 pb-5">
      <div className="flex flex-col gap-6 min-[886px]:justify-between min-[886px]:flex-row">
        <p className="text-white font-bold text-2xl md:text-3xl">HakimHub</p>
        <div className="flex gap-20 items-start flex-wrap">
          {footerLinks.map((footerLink, i) => (
            <div className="flex flex-col gap-4" key={i}>
              <p className="font-bold">{footerLink.title}</p>
              {footerLink.content.map((link, i) => (
                <div className="flex gap-3 items-center" key={i}>
                  <BiChevronRight />
                  <p className="font-light">{link}</p>
                </div>
              ))}
            </div>
          ))}
        </div>
      </div>

      <div>
        <hr className="-mx-24 text-gray-300 mb-5" />
        <div className="flex flex-col justify-center md:flex-row md:justify-between items-center gap-6">
          <div className="flex gap-10 font-semibold text-sm sm:text-base">
            <p>Privacy Policy</p>
            <p>Terms of Use</p>
          </div>
          <div className="flex gap-10">
            <FaLinkedinIn className="w-5 h-5" />
            <BsFacebook className="w-5 h-5" />
            <AiOutlineInstagram className="w-5 h-5" />
            <BiLogoTwitter className="w-5 h-5" />
          </div>
        </div>
      </div>
    </div>
  );
};

export default Footer;
