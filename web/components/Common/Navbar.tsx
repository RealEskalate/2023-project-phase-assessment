import React from "react";
import ProfileAvatar from "./ProfileAvatar";

export default function Navbar() {
  return (
    <div className="flex  justify-between px-12 py-2">
      <div className="flex  items-center">
        <svg
          className="w-14 h-14 shrink-0 flex items-center pb-2"
          viewBox="0 0 59 59"
          fill="none"
          xmlns="http://www.w3.org/2000/svg"
        >
          <g id="Frame">
            <path
              id="Vector"
              d="M31.7855 34.3864C30.9324 35.2265 30.9149 36.6005 31.7549 37.4537C32.5949 38.307 33.96 38.3245 34.8219 37.4843C34.8831 37.4231 34.9444 37.3531 34.9969 37.2918C35.7406 40.8273 36.0644 41.2999 36.5325 41.2999C36.585 41.2999 36.6419 41.2911 36.7032 41.2824C37.3507 41.1905 37.3638 41.1905 37.8713 32.6405C37.8801 32.4655 37.8932 32.2861 37.902 32.1111C37.9107 32.2248 37.9238 32.343 37.9326 32.448C38.5495 38.832 38.5495 38.832 39.0089 39.0071C39.5995 39.239 39.9014 38.7052 40.5445 37.5369C40.7152 37.2349 40.9689 36.7667 41.1308 36.5392C41.8833 36.6223 43.944 36.7842 44.5609 35.9835C44.6834 35.8304 44.8453 35.5766 45.0203 35.2834C45.2522 34.9202 45.7335 34.1545 46.0353 33.8613C46.1753 34.032 46.3503 34.3164 46.4904 34.5395C47.0766 35.4759 47.7373 36.5305 48.6517 36.5523H48.6823L53.4512 36.5611H54.9956V37.2437C54.9956 39.996 52.7643 42.2188 50.0211 42.2188H42.229V50.0249C42.229 52.7684 39.9976 55 37.2457 55H33.7543C31.0111 55 28.7798 52.7684 28.7798 50.0249V42.2232H20.9745C18.2313 42.2232 16 40.0003 16 37.2481V33.7563C16 31.004 18.2313 28.7812 20.9745 28.7812H28.7798V20.9751C28.7798 18.2316 31.0111 16 33.7543 16H37.2457C39.9976 16 42.229 18.2316 42.229 20.9751V28.7812H50.0255C52.7687 28.7812 55 31.004 55 33.7563V35.4103H53.4556L48.7129 35.4015C48.7129 35.4015 48.7042 35.4015 48.6954 35.4015C48.3935 35.4015 47.7285 34.3339 47.4748 33.927C47.1423 33.4019 46.8841 32.9906 46.5822 32.7718C46.3985 32.6318 46.1578 32.588 45.9303 32.6318C45.3003 32.7543 44.7622 33.555 44.0534 34.6708C43.9003 34.9246 43.7603 35.1478 43.6684 35.2615C43.384 35.4978 41.7521 35.4759 41.0477 35.3622C40.492 35.279 40.2164 35.7604 39.5558 36.9549C39.4158 35.7472 39.2407 33.9182 39.0964 32.343C38.4663 25.8145 38.4663 25.8145 37.9107 25.7052C37.7444 25.6745 37.5694 25.7139 37.4382 25.8189C37.1319 26.0508 37.1144 26.064 36.725 32.5705C36.6157 34.3558 36.4932 36.5217 36.3707 38.1451C36.2481 37.6156 36.1038 36.9593 35.9419 36.1454L35.92 36.0623C35.8588 35.756 35.6838 35.5766 35.4256 35.4759C35.3469 35.0909 35.1587 34.7233 34.8569 34.4214C34.0168 33.5638 32.6474 33.5507 31.7855 34.3864Z"
              fill="url(#paint0_linear_539_119)"
            />
          </g>
          <defs>
            <linearGradient
              id="paint0_linear_539_119"
              x1="19.1655"
              y1="42.8223"
              x2="54.7579"
              y2="26.877"
              gradientUnits="userSpaceOnUse"
            >
              <stop offset="4.1024e-07" stop-color="#7175B7" />
              <stop offset="0.0934" stop-color="#6E71B3" />
              <stop offset="0.6815" stop-color="#5B5CA0" />
              <stop offset="1" stop-color="#54549A" />
            </linearGradient>
          </defs>
        </svg>
        <h1 className="text-3xl text-[#424242] font-poppins font-extrabold tracking-wide">
          Hakim
        </h1>
        <h1 className="text-3xl text-[#FF7272] font-poppins tracking-wide font-extrabold">
          Hub
        </h1>
      </div>
      <div className="flex items-center">
        <ProfileAvatar />
      </div>
    </div>
  );
}
