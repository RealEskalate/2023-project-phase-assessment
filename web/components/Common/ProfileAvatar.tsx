import React from "react";
import Image from "next/image";

export default function ProfileAvatar() {
  return (
    <div className="flex  items-center gap-2">
      <Image
        className="w-10 h-10 rounded-full border border-[#6C63FF]"
        src="/images/Jonathan.jpeg"
        alt=""
        width={68}
        height={68}
      />
      <div className="flex items-center gap-2 font-poppins text-base tracking-tight ">
        Johnathan Alemayehu{" "}
        <span>
          <svg
            width="12"
            height="7"
            viewBox="0 0 12 7"
            fill="none"
            xmlns="http://www.w3.org/2000/svg"
          >
            <path
              id="Mask"
              fill-rule="evenodd"
              clip-rule="evenodd"
              d="M6.00025 6.33334C5.81025 6.33334 5.62108 6.26917 5.46692 6.14001L0.466916 1.97334C0.113583 1.67917 0.0652498 1.15334 0.36025 0.800007C0.654416 0.446673 1.17942 0.399173 1.53358 0.69334L6.00942 4.42334L10.4778 0.827507C10.8361 0.539173 11.3611 0.59584 11.6494 0.954173C11.9377 1.31251 11.8811 1.83667 11.5228 2.12584L6.52275 6.14917C6.37025 6.27167 6.18525 6.33334 6.00025 6.33334Z"
              fill="#231F20"
            />
          </svg>
        </span>
      </div>
    </div>
  );
}
