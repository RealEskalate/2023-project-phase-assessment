import Image from "next/image";
import Link from "next/link";

interface DoctorCardProps {
  doctor: any;
}

export default function DoctorCard({ doctor }: DoctorCardProps) {
  return (
    <Link href={`/doctor/${doctor._id}`}>
      <div className="w-[308px] rounded-3xl my-10 flex flex-col items-center p-5 gap-5 mx-auto drop-shadow shadow-neutral-200 shadow-xl">
        <div className="w-max">
          <Image
            src={doctor.photo}
            width={100}
            height={100}
            alt={doctor.fullName}
            className="w-28 rounded-full mx-auto -mt-16 border-[3px] border-primary object-cover max-h-28"
          />
        </div>
        <h1 className="text-center text-lg font-bold">{doctor.fullName}</h1>
        {doctor.speciality && (
          <span className="bg-gradient-to-br from-primary to-sky-500 px-5 py-px text-white text-base rounded-[44px]">
            {doctor.speciality[0].name}
          </span>
        )}
        <p className="text-base text-neutral-500">
          {doctor.institutionID_list.map((institution: any, index: number) => (
            <span key={index}>{institution.institutionName}</span>
          ))}
        </p>
      </div>
    </Link>
  );
}
