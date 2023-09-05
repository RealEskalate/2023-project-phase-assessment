import Image from "next/image";
import Link from "next/link";

const Footer = () => {
  return (
    <footer className="bg-blue-500 min-h-72 text-white">
      <div className="flex flex-col md:flex-row">
        <div className="md:w-1/2 p-16">
          <p className="text-3xl font-bold font-poppins">HakimHub</p>
        </div>
        <div className="md:w-1/2 p-6 md:p-16">
          <div className="flex gap-4 md:gap-16 font-light flex-col items-center  md:flex-row">
            <div className="flex flex-col">
              <p className="font-bold">Get Connected</p>
              <p>{"> For Physician"}</p>
              <p>{"> For Hospitals"}</p>
            </div>
            <div className="flex flex-col">
              <p className="font-bold">Actions</p>
              <p>{"> Find a doctor"}</p>
              <p>{"> Find a hospital"}</p>
            </div>
            <div className="flex flex-col">
              <p className="font-bold">Company</p>
              <p>{"> About us"}</p>
              <p>{"> Career"}</p>
              <p>{"> Join our team"}</p>
            </div>
          </div>
        </div>
      </div>
      <hr className="mx-14" />
      <div className="flex flex-col md:flex-row justify-between p-3">
        <div className="w-full md:w-1/2 flex justify-start gap-8 md:gap-32 px-16">
          <p className="semibold">Privacy Policy</p>
          <p className="semibold">Terms of Use</p>
        </div>
        <section className="flex justify-center gap-8 w-full md:w-1/2 pr-24">
          <Link href={"#"}>
            <Image
              src="/images/facebook-icon.png"
              alt="facebook"
              width={28}
              height={28}
            />
          </Link>
          <Link href={"#"}>
            <Image
              src="/images/linkedin-icon.png"
              alt="linkedin"
              width={28}
              height={28}
            />
          </Link>
          <Link href={"#"}>
            <Image
              src="/images/instagram-icon.png"
              alt="instagram"
              width={28}
              height={28}
            />
          </Link>
          <Link href={"#"}>
            <Image
              src="/images/twitter-icon.png"
              alt="twitter"
              width={28}
              height={28}
            />
          </Link>
        </section>
      </div>
    </footer>
  );
};

export default Footer;
