import Image from "next/image";

const CardItem = ({ doctor }: any) => {
  console.log(doctor);
  return (
    <div className="rounded-b-xl shadow-lg py-8 px-8 mt-24">
      <div className="flex items-center justify-center p-2 py-6">
        <Image
          src={doctor.photo}
          width={130}
          alt="Profile"
          height={130}
          className="border-4 border-blue-500 rounded-full -mt-28"
        />
      </div>
      <h3 className="text-center font-semibold text-base mb-2">
        {doctor.fullName}
      </h3>
      <div className="text-center my-1">
        <button className="rounded-3xl bg-blue-500 py-1 px-3 text-white mb-2">
          {doctor.speciality[0].name}
        </button>
      </div>
      <p className="text-base text-neutral-500 text-center">
        {doctor.institutionID_list.map((institution: any, index: number) => (
          <span className="text-slate-400 opacity-75" key={index}>
            {institution.institutionName}
          </span>
        ))}
      </p>
    </div>
  );
};

export default CardItem;
