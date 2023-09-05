import Image from "next/image";
import Facebook from "@/public/assets/images/fb.png";
import Instagram from "@/public/assets/images/insta.png";
import LinkedIn from "@/public/assets/images/linkedIn.png";
import Twitter from "@/public/assets/images/twitter.png";
const Footer = () => {
  return (
    <footer className="bg-primary">
      <div className="px-14 py-18 mx-auto ">
        <div className="flex justify-between items-center py-12 px-12">
          <div className="px-20">
            <h2 className="text-2xl font-extrabold text-white">HakimHub</h2>
          </div>
          <div className="flex items-center space-x-6 justify-evenly text-white">
            <div className="flex flex-col justify-center items-start">
              <h3 className="font-semibold text-base mb-4">Get Connected</h3>
              <ul className="font-light text-sm">
                <li>For Physicians</li>
                <li>For Hospitals</li>
              </ul>
            </div>
            <div className="flex flex-col justify-center items-start">
              <h3 className="font-semibold text-base mb-4">Actions</h3>
              <ul className="font-light text-sm">
                <li>Find a doctor</li>
                <li>Find a hospital</li>
              </ul>
            </div>
            <div className="flex flex-col justify-center items-start">
              <h3 className="font-semibold text-base mb-4">Company</h3>
              <ul className="font-light text-sm">
                <li>About Us</li>
                <li>Career</li>
                <li>Join our team</li>
              </ul>
            </div>
          </div>
        </div>
        <div className="border-t border-slate-100 px-20 w-full">
          <div className="flex py-13 px-4 items-center justify-between">
            <div className="flex text-white items-center space-x-4 cursor-pointer">
              <p className="text-[18px] font-bold">Privacy Policy</p>
              <p className="text-[18px] font-bold">Terms of Use</p>
            </div>
            <div className="flex items-center space-x-8 py-3 px-2">
              <Image src={Facebook} alt="fb" />
              <Image src={LinkedIn} alt="fb" />
              <Image src={Instagram} alt="fb" />
              <Image src={Twitter} alt="fb" />
            </div>
          </div>
        </div>
      </div>
    </footer>
  );
};

export default Footer;
