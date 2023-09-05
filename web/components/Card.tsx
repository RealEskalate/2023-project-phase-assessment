import { DoctorData } from "@/types";
import Link from "next/link";
import Image from "next/image";

type Props = {
  doctor: DoctorData;
};

const Card: React.FC<Props> = ({ doctor }) => {
  return (
    <Link
      href={doctor._id}
      className="p-4 flex flex-col items-center justify-center gap-4 hover:shadow-lg shadow-md shadow-gray-200 rounded-2xl"
    >
      <Image
        src={doctor.photo}
        alt={`${doctor.fullName} photo`}
        height={100}
        width={100}
        className="rounded-full border-4 object-cover border-[#6C63FF] w-32 h-32"
      />
      <h2 className="text-lg font-bold text-center"> {doctor.fullName} </h2>
      {doctor.speciality.length > 0 && (
        <p className="rounded-full bg-[#6C63FF] py-1 px-3 text-white text-light">
          {doctor.speciality[0].name.split("&")[0]}
        </p>
      )}
      <p>{doctor.mainInstitution.institutionName}</p>
    </Link>
  );
};

export default Card;
