"use client";
import PageLoader from "@/components/common/Loader";
import { useGetDoctorDetailQuery } from "@/utils/redux/services/doctorApi";
import Image from "next/image";
import { useParams } from "next/navigation";
import { useRouter } from "next/navigation";
export default function page() {
  const router = useRouter();
  const { doctor_id }: { doctor_id?: string } = useParams();
  const {
    data: doctor,
    isLoading,
    isError,
    error,
  } = useGetDoctorDetailQuery(doctor_id!);

  if (isLoading) return <PageLoader />;
  if (error) throw new Error("Invalid profile credential!");

  console.log(doctor);
  return (
    <main className="min-h-screen w-full lg:px-24 p-5">
      <div>
        <Image
          src="/imgs/cover.png"
          alt=""
          width={500}
          height={200}
          className="w-full max-h-[288px] object-cover rounded-3xl md:h-auto h-40"
        />
        <Image
          src={doctor.photo}
          width={100}
          height={100}
          alt={doctor.fullName}
          className="md:w-48 rounded-full mx-auto md:-mt-16 z-50 border-[3px] border-primary object-cover max-h-48  drop-shadow shadow-blue-300 shadow-xl w-36 -mt-12"
        />
      </div>
      <div className="mt-10">
        <div className="md:w-[60%]">
          <div className="flex justify-between">
            <div>
              <h1 className="md:text-2xl text-lg font-bold">
                {doctor.fullName}
              </h1>
              {doctor.speciality && (
                <span className="text-[#4E4E4E] md:text-xl text-base">
                  {doctor.speciality[0].name}
                </span>
              )}
            </div>
            <div>
              <p className="md:text-base text-xs text-neutral-500 text-right break-words">
                Addis Ababa University
              </p>
              <p className="md:text-xl text-xs text-neutral-500">
                {doctor.institutionID_list[0].institutionName}
              </p>
            </div>
          </div>
          <div className="mt-14">
            <h2 className="font-extrabold text-lg">About</h2>
            <p className="text-[#4E4E4E] md:text-base text-sm">
              Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis
              pellentesque purus sit amet mi aliquam, id dictum augue vulputate.
              Pellentesque porta, ligula non pulvinar sollicitudin, dolor nunc
              molestie dui, sit amet volutpat eros nibh vitae magna. Nullam
              tempor, purus nec rutrum varius, arcu massa scelerisque diam, nec
              vestibulum diam neque a massa. Mauris tempor odio in ornare
              cursus. Maecenas in ultricies sapien. Suspendisse dolor turpis,
              pretium vitae lacus eget, condimentum aliquam diam.
            </p>
          </div>
          <div className="mt-14">
            <h2 className="font-extrabold text-lg">Education</h2>
            {new Array(2).fill(0).map((_, index) => (
              <div className="flex justify-between items-center my-5">
                <div>
                  <h3 className="md:text-xl text-base font-semibold">
                    Addis Ababa University
                  </h3>
                  <p className="md:text-base text-sm font-light">
                    B. Sc Medicine
                  </p>
                </div>
                <p className="text-base font-light">2003 - 2008</p>
              </div>
            ))}
          </div>
          <div className="mt-16 space-y-5">
            <h2 className="font-extrabold text-lg">Contact Info</h2>
            <div className="flex gap-3">
              <div>
                <svg
                  width="16"
                  height="17"
                  viewBox="0 0 16 17"
                  fill="none"
                  xmlns="http://www.w3.org/2000/svg"
                  className="my-1"
                >
                  <path
                    d="M3.1675 7.44125C4.4275 9.9175 6.4575 11.9387 8.93375 13.2075L10.8587 11.2825C11.095 11.0463 11.445 10.9675 11.7513 11.0725C12.7312 11.3962 13.79 11.5712 14.875 11.5712C15.3562 11.5712 15.75 11.965 15.75 12.4462V15.5C15.75 15.9812 15.3562 16.375 14.875 16.375C6.65875 16.375 0 9.71625 0 1.5C0 1.01875 0.39375 0.625 0.875 0.625H3.9375C4.41875 0.625 4.8125 1.01875 4.8125 1.5C4.8125 2.59375 4.9875 3.64375 5.31125 4.62375C5.4075 4.93 5.3375 5.27125 5.0925 5.51625L3.1675 7.44125Z"
                    fill="#484848"
                  />
                </svg>
              </div>
              <div>
                <h2 className="text-primary font-semibold">Phone Number:</h2>
                <p>+25111763498</p>
              </div>
            </div>
            <div className="flex gap-3">
              <div>
                <svg
                  width="18"
                  height="15"
                  viewBox="0 0 18 15"
                  fill="none"
                  xmlns="http://www.w3.org/2000/svg"
                  className="my-1"
                >
                  <path
                    d="M15.75 0.5H1.75C0.7875 0.5 0.00874999 1.2875 0.00874999 2.25L0 12.75C0 13.7125 0.7875 14.5 1.75 14.5H15.75C16.7125 14.5 17.5 13.7125 17.5 12.75V2.25C17.5 1.2875 16.7125 0.5 15.75 0.5ZM15.75 4L8.75 8.375L1.75 4V2.25L8.75 6.625L15.75 2.25V4Z"
                    fill="#484848"
                  />
                </svg>
              </div>
              <div>
                <h2 className="text-primary font-semibold">Email:</h2>
                <p>fasiltefera@stpaul.com</p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </main>
  );
}
