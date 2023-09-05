"use client";
import { useGetDoctorByIdQuery } from "@/lib/redux/services/doctorsApi";
import Image from "next/image";

type Props = {
  params: {
    id: string;
  };
};

const page: React.FC<Props> = ({ params: { id } }) => {
  const { data, error, isLoading } = useGetDoctorByIdQuery(id);

  if (isLoading) return <p>Loading...</p>;
  if (error || !data) return <p>Error has happened</p>;

  return (
    <section className="w-full flex flex-col gap-4">
      <div className="w-full flex flex-col items-center">
        <Image
          src="/BgImage.png"
          alt="background image"
          width={1440}
          height={300}
          className="w-full"
        />
        <Image
          src={data.photo}
          alt={`${data.fullName} photo`}
          height={200}
          width={200}
          className="rounded-full border-4 -mt-28 border-[#6C63FF]"
        />
      </div>
      <div className="md:w-3/5 px-4 flex flex-col gap-12">
        <div className="flex flex-col gap-2">
          <h2 className="text-2xl font-bold"> {data.fullName} </h2>
          <div className="flex justify-between items-center text-slate-500 font-light">
            <p>
              {data.speciality.length > 0 &&
                data.speciality.map((speciality) => (
                  <span key={speciality.name}>{speciality.name}</span>
                ))}
            </p>
            <p>
              {data.institutionID_list.length > 0 &&
                data.institutionID_list[0].institutionName}
            </p>
          </div>
        </div>
        {data.summary && (
          <div className="flex flex-col gap-2">
            <h3 className="text-xl font-bold">About</h3>
            <p className="text-justify font-light text-sm ">
              {data.summary}
            </p>
          </div>
        )}
        {data.education.length > 0 && (
          <div className="flex flex-col gap-2">
            <h3 className="text-xl font-bold">Education</h3>
            {data.education.map((education) => education)}
          </div>
        )}
        {data.emails.length > 0 && (
          <div className="flex flex-col gap-2">
            <h3 className="text-xl font-bold">Contact Info</h3>
            <p>
              <span className="font-bold">Email: </span>
              {data.emails.map((email) => (
                <span className="font-light">{email}</span>
              ))}
            </p>
          </div>
        )}
      </div>
    </section>
  );
};

export default page;
