import Image from "next/image";
import { Daum } from "@/type/doctors-list";


const DoctorCard = ({
    photo,
    fullName,
    mainInstitution,
    speciality,
  }: Daum) => {
    return (
      <div className="w-72 p-10 shadow-lg flex flex-col gap-3 items-center">
        <Image
          src={photo}
          alt="profile-pic"
          className="inline object-cover self-center w-16 h-16 mr-2 rounded-full border-4 border-Sub-Primary"
          width={120}
          height={120}
        />
        <p>{fullName}</p>
        <p className="bg-Sub-Primary px-3 py-1 rounded-2xl">
          {speciality}
        </p>
        <p>{mainInstitution}</p>
      </div>
    );
  };
  
  export default DoctorCard;