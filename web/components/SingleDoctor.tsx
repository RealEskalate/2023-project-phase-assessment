import Link from "next/link";

const SingleDoctor = (prop:any) => {
    const {doctor}:any = prop
    return ( (
        <Link
          href={`/doctor/${doctor._id}`}
          className="rounded-lg bg-white w-72 mx-8 flex flex-col items-center text-center shadow-2xl my-10"
          key={doctor._id}
        >
          <div className="rounded-full overflow-hidden w-32 border-indigo-400 border-4 my-6 max-h-32">
            <img src={doctor.photo} alt={doctor.name} />
          </div>
          <h2 className="font-poppins text-xl font-medium my-4">
            {doctor.fullName}
          </h2>
          <div className="bg-indigo-500 text-white rounded-full w-1/2 flex justify-center my-4 h-10 items-center">
            <p className="font-light font-poppins ">
              {doctor.speciality&&doctor.speciality.map((sp:any)=><p>{sp.name}</p>)}
            </p>
          </div>
          <div className="flex my-4">
            {doctor.institutionID_list&&doctor.institutionID_list.map((inst: any, index: number) => (
              <p>
                {inst.institutionName +
                  (index != doctor.institutionID_list.length - 1
                    ? " | "
                    : " ")}
              </p>
            ))}
          </div>
        </Link>
      ) );
}
 
export default SingleDoctor;