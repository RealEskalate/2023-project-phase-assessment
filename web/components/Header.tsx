import Image from "next/image";

export default function Header() {
  return (
    <div className="flex justify-etween">
      <div>Hakim u</div>
      <div className="flex">
        <Image
          width={50}
          height={50}
          src="Header/profile-picture"
          alt="profile-picture"
        />
        <p>Jonathan Alemayehu</p>
        <p>icon</p>
      </div>
    </div>
  );
}
