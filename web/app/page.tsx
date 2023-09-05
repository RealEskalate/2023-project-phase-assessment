import Link from "next/link";

export default function Home() {
  return (
    <div>
      <Link className=" flex justify-center" href={'/doctors'}>Doctors</Link>
    </div>
  )
}
