import SearchBar from "@/components/common/SearchBar";
import DoctorList from "@/components/doctor/DoctorList";
import Image from "next/image";

export default function Home() {
  return (
    <main className="min-h-screen w-full lg:px-16 px-5">
      <div className="lg:px-20">
        <SearchBar />
      </div>
      <div className="w-full mt-10">
        <DoctorList />
      </div>
    </main>
  );
}
