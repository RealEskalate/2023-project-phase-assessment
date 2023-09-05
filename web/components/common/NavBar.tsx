import Image from "next/image";
import Link from "next/link";

export default function NavBar() {
  return (
    <div className="flex justify-between p-5">
      <Link href={"/"} className="flex gap-3 items-center">
        <Image src="/imgs/logo-vector.png" alt="logo" width={39} height={39} />
        <h1 className="text-3xl font-bold">
          <span className="text-primary-text">Hakim</span>
          <span className="text-secondary">Hub</span>
        </h1>
      </Link>
      <div>
        <div className="flex items-center">
          <Image src="/imgs/avatar.png" alt="Avatar" width={68} height={68} />
          <div className="sm:flex gap-3 ml-3 items-center hidden ">
            <p className="text-base">Jonathan Alemayehu</p>
            <svg
              width="20"
              height="20"
              viewBox="0 0 20 20"
              fill="none"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path
                fillRule="evenodd"
                clipRule="evenodd"
                d="M10.0002 13.3333C9.81025 13.3333 9.62108 13.2692 9.46692 13.14L4.46692 8.97334C4.11358 8.67917 4.06525 8.15334 4.36025 7.80001C4.65442 7.44667 5.17942 7.39917 5.53358 7.69334L10.0094 11.4233L14.4778 7.82751C14.8361 7.53917 15.3611 7.59584 15.6494 7.95417C15.9377 8.31251 15.8811 8.83667 15.5228 9.12584L10.5228 13.1492C10.3703 13.2717 10.1852 13.3333 10.0002 13.3333Z"
                fill="#231F20"
              />
              <mask
                id="mask0_1_635"
                maskUnits="userSpaceOnUse"
                x="4"
                y="7"
                width="12"
                height="7"
              >
                <path
                  fillRule="evenodd"
                  clipRule="evenodd"
                  d="M10.0002 13.3333C9.81025 13.3333 9.62108 13.2692 9.46692 13.14L4.46692 8.97334C4.11358 8.67917 4.06525 8.15334 4.36025 7.80001C4.65442 7.44667 5.17942 7.39917 5.53358 7.69334L10.0094 11.4233L14.4778 7.82751C14.8361 7.53917 15.3611 7.59584 15.6494 7.95417C15.9377 8.31251 15.8811 8.83667 15.5228 9.12584L10.5228 13.1492C10.3703 13.2717 10.1852 13.3333 10.0002 13.3333Z"
                  fill="white"
                />
              </mask>
              <g mask="url(#mask0_1_635)">
                <rect width="20" height="20" fill="#0D1C2E" />
              </g>
            </svg>
          </div>
        </div>
      </div>
    </div>
  );
}
