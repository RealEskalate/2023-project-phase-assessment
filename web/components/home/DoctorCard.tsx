import { DoctorInfo } from "@/types/doctors/doctor";
import Image from "next/image";

const DoctorCard: React.FC<{ doctor: DoctorInfo }> = ({
  doctor,
}: {
  doctor: DoctorInfo;
}) => {
  return (
    <div className="flex flex-col justify-center items-center gap-3 rounded-3xl px-16 pb-6 shadow-lg ">
      <Image
        className="w-24 h-24 border-4 border-primary rounded-full -mt-12"
        src={doctor.photo}
        width={90}
        height={90}
        alt="profile"
      />
      <p className="font-semibold text-lg">{doctor.fullName}</p>
      <p className="font-light text-sm px-2 py-1 bg-primary rounded-full text-[#DDDCEF]">
        {doctor.speciality.map((speciality) => speciality.name).join(", ")}
      </p>
      <p className="text-sm text-[#686868]">
        {doctor.institutionID_list
          .map((intsitution) => intsitution.institutionName)
          .join("| ")}
      </p>
    </div>
  );
};

export default DoctorCard;
