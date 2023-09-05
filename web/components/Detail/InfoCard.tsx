import React from "react";

interface Prop {
  name: string;
  speciality: string;
  institution: string;
  summary: string;
}

export default function InfoCard({
  name,
  speciality,
  institution,
  summary,
}: Prop) {
  return (
    <div className=" py-5 flex px-20">
      <div className="w-3/4  flex flex-col gap-12">
        <div className="flex justify-between">
          <div className="flex flex-col">
            <h1 className="text-2xl font-semibold font-poppins">
              {name}
              Dr Fasil Tefera
            </h1>
            <p className="text-base font-poppins font-light text-[#4E4E4E]">
              {speciality}
              Internal Medicine
            </p>
          </div>
          <div className="flex flex-col items-end">
            <p className="text-sm font-normal text-[#686868] font-poppins">
              Addis Ababa University
            </p>
            <p className="text-base font-normal text-[#686868] font-poppins">
              {institution}
              Washington Medical Center
            </p>
          </div>
        </div>
        <div className="flex flex-col gap-3">
          <h1 className="text-xl font-bold font-poppins">About</h1>
          <p className="text-base font-poppins">
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis
            pellentesque purus sit amet mi aliquam, id dictum augue vulputate.
            Pellentesque porta, ligula non pulvinar sollicitudin, dolor nunc
            molestie dui, sit amet volutpat eros nibh vitae magna. Nullam
            tempor, purus nec rutrum varius, arcu massa scelerisque diam, nec
            vestibulum diam neque a massa. Mauris tempor odio in ornare cursus.
            Maecenas in ultricies sapien. Suspendisse dolor turpis, pretium
            vitae lacus eget, condimentum aliquam diam.
          </p>
        </div>
        <div className="flex flex-col gap-3">
          <div>
            <h1 className="text-xl font-bold font-poppins">Education</h1>
          </div>
          <div className="flex justify-between">
            <div className="flex flex-col ">
              <h1 className="text-base font-medium font-poppins">
                Addis Ababa University
              </h1>
              <p className="text-sm font-poppins">B. Sc Medicine</p>
            </div>
            <p className="text-sm font-poppins">2003 - 2007</p>
          </div>
          <div className="flex justify-between">
            <div className="flex flex-col">
              <h1 className="text-base font-medium font-poppins">
                Addis Ababa University
              </h1>
              <p className="text-sm font-poppins">B. Sc Medicine</p>
            </div>
            <p className="font-poppins text-sm">2007 - 2011</p>
          </div>
        </div>
        <div className="flex flex-col gap-3">
          <div>
            <h1 className="text-xl font-bold font-poppins">Contact Info</h1>
          </div>
          <div>
            <h1 className="flex gap-2 items-center">
              <svg
                width="16"
                height="17"
                viewBox="0 0 16 17"
                fill="none"
                xmlns="http://www.w3.org/2000/svg"
              >
                <path
                  id="Vector"
                  d="M3.1675 7.44125C4.4275 9.9175 6.4575 11.9387 8.93375 13.2075L10.8587 11.2825C11.095 11.0463 11.445 10.9675 11.7513 11.0725C12.7312 11.3962 13.79 11.5712 14.875 11.5712C15.3562 11.5712 15.75 11.965 15.75 12.4462V15.5C15.75 15.9812 15.3562 16.375 14.875 16.375C6.65875 16.375 0 9.71625 0 1.5C0 1.01875 0.39375 0.625 0.875 0.625H3.9375C4.41875 0.625 4.8125 1.01875 4.8125 1.5C4.8125 2.59375 4.9875 3.64375 5.31125 4.62375C5.4075 4.93 5.3375 5.27125 5.0925 5.51625L3.1675 7.44125Z"
                  fill="#484848"
                />
              </svg>
              <span className="text-[#7879F1] font-poppins font-bold">
                Phone Number :
              </span>
            </h1>
            <p className="px-6">+251972226190</p>
          </div>
          <div>
            <h1 className="flex gap-2 items-center">
              <svg
                width="18"
                height="15"
                viewBox="0 0 18 15"
                fill="none"
                xmlns="http://www.w3.org/2000/svg"
              >
                <path
                  id="Vector"
                  d="M15.75 0.5H1.75C0.7875 0.5 0.00874999 1.2875 0.00874999 2.25L0 12.75C0 13.7125 0.7875 14.5 1.75 14.5H15.75C16.7125 14.5 17.5 13.7125 17.5 12.75V2.25C17.5 1.2875 16.7125 0.5 15.75 0.5ZM15.75 4L8.75 8.375L1.75 4V2.25L8.75 6.625L15.75 2.25V4Z"
                  fill="#484848"
                />
              </svg>
              <span className="text-[#7879F1] font-poppins font-bold">
                Email :
              </span>
            </h1>
            <p className="px-6">abcdefg@gmail.com</p>
          </div>
        </div>
      </div>
      <div className="w-1/2"></div>
    </div>
  );
}
