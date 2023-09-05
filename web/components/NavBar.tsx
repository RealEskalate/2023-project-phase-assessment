import Image from "next/image";
import Link from "next/link";

const NavBar = () => {
  return (
    <nav className="flex items-center justify-between py-3">
      <Link href="/" className="flex items-end gap-2">
        <Image src="/HakimLogo.svg" alt="Logo" height={40} width={40} />
        <p className="text-3xl font-poppins">
          Hakim<span className="text-red-500">Hub</span>
        </p>
      </Link>
      <div className="flex items-center gap-2">
        <Image
          src="/PersonImg.svg"
          alt="Demo User"
          height={54}
          width={54}
          className="rounded-full"
        />
        <p className="text-slate-700 font-poppins">Jonathan Alemayehu</p>
        <Image src="/ArrowDown.svg" alt="Arrow Down" height={12} width={12} />
      </div>
    </nav>
  );
};

export default NavBar;
