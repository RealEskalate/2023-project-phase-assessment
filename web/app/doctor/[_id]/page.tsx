"use client";
import { useParams } from "next/navigation";
import Image from "next/image";
import bg_image from "@/public/assets/images/bg_background.png";

import { useGetDoctorDetailQuery } from "@/lib/redux/slices/doctorsApi";

const DoctorProfile = () => {
  const params = useParams();
  const id: any = params._id;
  console.log(id);

  const { data, isLoading, isError } = useGetDoctorDetailQuery(id);
  if (isLoading)
    return (
      <div className="flex justify-center items-center w-screen min-h-[55vh]">
        Loading...
      </div>
    );

  return (
    <section className="container mx-auto py-12 px-24 min-h-[55vh]">
      <Image
        src={bg_image}
        alt="background Image"
        className="w-full h-52 rounded-2xl"
      />
      <div className="flex items-center justify-center px-12">
        <Image
          src={data?.photo}
          alt="profile picture"
          width={40}
          height={40}
          className="rounded-full h-40 w-40 z-10 border-4 border-blue-800 -mt-24"
        />
      </div>
      <div className="flex justify-between items-center py-4">
        <div className="flex flex-col justify-center py-12">
          <h2 className="font-bold text-[24px]">{data.fullName}</h2>
          <p className="font-light text-base">Internal Medicine</p>
        </div>
        <div>
          <h4 className="text-sm font-light opacity-90">
            Addis Ababa University
          </h4>
          <p>Washington Medical Center</p>
        </div>
      </div>
      <div>
        <h3 className="font-bold text-base text-left">About</h3>
        <p className="font-light text-sm my-4 ">
          Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis
          pellentesque purus sit amet mi aliquam, id dictum augue vulputate.
          Pellentesque porta, ligula non pulvinar sollicitudin, dolor nunc
          molestie dui, sit amet volutpat eros nibh vitae magna. Nullam tempor,
          purus nec rutrum varius, arcu massa scelerisque diam, nec vestibulum
          diam neque a massa. Mauris tempor odio in ornare cursus. Maecenas in
          ultricies sapien. Suspendisse dolor turpis, pretium vitae lacus eget,
          condimentum aliquam diam.
        </p>
      </div>
      <div>
        <h4 className="text-lg font-extrabold pt-5 my-4">Education</h4>
      </div>
      <div className="flex justify-between items-center my-4">
        <div className="flex flex-col">
          <p>Addis Ababa University</p>
          <p>B. Sc Medicine</p>
        </div>
        <p className="font-extralight text-sm">2003 - 2007</p>
      </div>
      <div className="flex justify-between items-center my-4">
        <div className="flex flex-col">
          <p>Harvard University</p>
          <p>M. Sc Internal Medicine</p>
        </div>
        <p className="font-extralight text-sm">2007 - 2011</p>
      </div>

      <div>
        <p className="text-lg font-extrabold pt-16">Contact Info</p>
        <p className="text-lg font-bold pt-5 text-[#7879F1]">Phone Number</p>
        <p className="font-light">+25111763498</p>
        <p className="text-lg font-bold pt-5 text-[#7879F1]">Email</p>
        <p className="font-light">fasiltefera@stpaul.com</p>
      </div>
    </section>
  );
};

export default DoctorProfile;
