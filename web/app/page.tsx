import Footer from "@/components/Common/Footer";
import DoctorDetail from "@/components/Detail/DoctorDetail";
import DoctorImageCard from "@/components/Detail/DoctorImageCard";
import InfoCard from "@/components/Detail/InfoCard";
import DoctorCard from "@/components/Home/DoctorCard";
import DoctorList from "@/components/Home/DoctorList";
import { useGetAllDoctorsQuery } from "@/lib/redux/services/doctorsApi";
import Image from "next/image";

export default function Home() {
  return (
    <div className="px-14 mt-10">
      <DoctorList />
    </div>
  );
}
