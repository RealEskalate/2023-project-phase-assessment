import React from "react";

export default function Footer() {
  return (
    <div className="w-full flex flex-col gap-20 bg-[#7879F1] mt-10 text-white py-5">
      <div className=" h-3/4 flex justify-between px-5">
        <div className="flex py-8 text-3xl text-white font-poppins font-bold ">
          HakimHub
        </div>
        <div className="flex  gap-9 space-x-5  py-8">
          <div className="flex flex-col gap-3 ">
            <h1 className="text-base text-white font-poppins font-semibold">
              Get Connected
            </h1>
            <p className="flex items-center gap-1 text-sms">
              <svg
                className="w-2 h-2"
                viewBox="0 0 8 8"
                fill="none"
                xmlns="http://www.w3.org/2000/svg"
              >
                <path
                  id="coolicon"
                  d="M7.26117 4.05604L2.00578 0.222534L0.769531 1.12446L4.79129 4.05859L0.769531 6.98826L2.00578 7.89019L7.26117 4.05604Z"
                  fill="white"
                />
              </svg>
              <span>For Physicians</span>
            </p>
            <p className="flex items-center gap-1 text-sm">
              <svg
                className="w-2 h-2"
                viewBox="0 0 8 8"
                fill="none"
                xmlns="http://www.w3.org/2000/svg"
              >
                <path
                  id="coolicon"
                  d="M7.26117 4.05604L2.00578 0.222534L0.769531 1.12446L4.79129 4.05859L0.769531 6.98826L2.00578 7.89019L7.26117 4.05604Z"
                  fill="white"
                />
              </svg>
              <span>For Physicians</span>
            </p>
          </div>
          <div className="flex flex-col gap-3 ">
            <h1 className="text-base text-white font-poppins font-semibold">
              Actions
            </h1>
            <p className="flex items-center gap-1 text-sms">
              <svg
                className="w-2 h-2"
                viewBox="0 0 8 8"
                fill="none"
                xmlns="http://www.w3.org/2000/svg"
              >
                <path
                  id="coolicon"
                  d="M7.26117 4.05604L2.00578 0.222534L0.769531 1.12446L4.79129 4.05859L0.769531 6.98826L2.00578 7.89019L7.26117 4.05604Z"
                  fill="white"
                />
              </svg>
              <span>Find a doctor</span>
            </p>
            <p className="flex items-center gap-1 text-sm">
              <svg
                className="w-2 h-2"
                viewBox="0 0 8 8"
                fill="none"
                xmlns="http://www.w3.org/2000/svg"
              >
                <path
                  id="coolicon"
                  d="M7.26117 4.05604L2.00578 0.222534L0.769531 1.12446L4.79129 4.05859L0.769531 6.98826L2.00578 7.89019L7.26117 4.05604Z"
                  fill="white"
                />
              </svg>
              <span>Find a hospital</span>
            </p>
          </div>
          <div className="flex flex-col gap-3 ">
            <h1 className="text-base text-white font-poppins font-semibold">
              Company
            </h1>
            <p className="flex items-center gap-1 text-sms">
              <svg
                className="w-2 h-2"
                viewBox="0 0 8 8"
                fill="none"
                xmlns="http://www.w3.org/2000/svg"
              >
                <path
                  id="coolicon"
                  d="M7.26117 4.05604L2.00578 0.222534L0.769531 1.12446L4.79129 4.05859L0.769531 6.98826L2.00578 7.89019L7.26117 4.05604Z"
                  fill="white"
                />
              </svg>
              <span>About Us</span>
            </p>
            <p className="flex items-center gap-1 text-sm">
              <svg
                className="w-2 h-2"
                viewBox="0 0 8 8"
                fill="none"
                xmlns="http://www.w3.org/2000/svg"
              >
                <path
                  id="coolicon"
                  d="M7.26117 4.05604L2.00578 0.222534L0.769531 1.12446L4.79129 4.05859L0.769531 6.98826L2.00578 7.89019L7.26117 4.05604Z"
                  fill="white"
                />
              </svg>
              <span>Career</span>
            </p>
            <p className="flex items-center gap-1 text-sm">
              <svg
                className="w-2 h-2"
                viewBox="0 0 8 8"
                fill="none"
                xmlns="http://www.w3.org/2000/svg"
              >
                <path
                  id="coolicon"
                  d="M7.26117 4.05604L2.00578 0.222534L0.769531 1.12446L4.79129 4.05859L0.769531 6.98826L2.00578 7.89019L7.26117 4.05604Z"
                  fill="white"
                />
              </svg>
              <span>Join our team</span>
            </p>
          </div>
          <div></div>
          <div></div>
        </div>
      </div>
      <div className=" h-1/4 flex justify-between px-20 py-2 w-[90%] border-t border-white">
        <div className="flex justify-between  gap-32 text-base font-poppins font-semibold">
          <h1>Privacy Policy</h1>
          <h1>Terms of Use</h1>
        </div>
        <div className="flex gap-10 justify-end items-center">
          <span>
            <svg
              width="21"
              height="21"
              viewBox="0 0 21 21"
              fill="none"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path
                id="coolicon"
                d="M0.931152 10.289C0.932316 15.2084 4.50955 19.3971 9.36815 20.168V13.179H6.83115V10.289H9.37115V8.08903C9.2576 7.04657 9.61367 6.00762 10.3428 5.25396C11.0719 4.5003 12.0985 4.11004 13.1442 4.18903C13.8947 4.20115 14.6433 4.268 15.3842 4.38903V6.84803H14.1202C13.685 6.79104 13.2475 6.93475 12.9309 7.2387C12.6143 7.54264 12.4529 7.97392 12.4922 8.41103V10.289H15.2632L14.8202 13.18H12.4922V20.168C17.7466 19.3376 21.4312 14.5388 20.8767 9.24811C20.3221 3.9574 15.7224 0.0269607 10.41 0.30421C5.09751 0.581459 0.931997 4.96934 0.931152 10.289Z"
                fill="white"
              />
            </svg>
          </span>
          <span>
            <svg
              width="19"
              height="19"
              viewBox="0 0 19 19"
              fill="none"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path
                id="coolicon"
                d="M10.9316 18.2904H6.93164V6.29041H10.9316V8.29041C11.7843 7.20566 13.0773 6.55898 14.4566 6.52741C16.9372 6.54118 18.9388 8.55978 18.9317 11.0404V18.2904H14.9316V11.5404C14.7717 10.423 13.8134 9.59398 12.6846 9.59641C12.1909 9.61201 11.7249 9.82818 11.3941 10.195C11.0633 10.5619 10.8963 11.0477 10.9316 11.5404V18.2904ZM4.93164 18.2904H0.931641V6.29041H4.93164V18.2904ZM2.93164 4.29041C1.82707 4.29041 0.931641 3.39497 0.931641 2.29041C0.931641 1.18584 1.82707 0.290405 2.93164 0.290405C4.03621 0.290405 4.93164 1.18584 4.93164 2.29041C4.93164 2.82084 4.72093 3.32955 4.34585 3.70462C3.97078 4.07969 3.46207 4.29041 2.93164 4.29041Z"
                fill="white"
              />
            </svg>
          </span>
          <span>
            <svg
              width="19"
              height="19"
              viewBox="0 0 19 19"
              fill="none"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path
                id="coolicon"
                d="M9.93164 18.3264C7.47164 18.3264 7.18164 18.3134 6.22164 18.2714C5.47301 18.2468 4.73407 18.0946 4.03664 17.8214C2.82995 17.3518 1.87578 16.3973 1.40664 15.1904C1.14395 14.4904 1.00226 13.7509 0.987641 13.0034C0.931641 12.0454 0.931641 11.7314 0.931641 9.29041C0.931641 6.82341 0.944641 6.53541 0.987641 5.58041C1.00258 4.83393 1.14426 4.09541 1.40664 3.39641C1.87527 2.18793 2.83099 1.23258 4.03964 0.764405C4.73828 0.500608 5.47699 0.35855 6.22364 0.344405C7.17864 0.290405 7.49264 0.290405 9.93164 0.290405C12.4116 0.290405 12.6966 0.303405 13.6416 0.344405C14.3902 0.358672 15.1309 0.500715 15.8316 0.764405C17.0399 1.23311 17.9955 2.18828 18.4646 3.39641C18.7318 4.1056 18.8742 4.85566 18.8856 5.61341C18.9416 6.57141 18.9416 6.88441 18.9416 9.32441C18.9416 11.7644 18.9276 12.0844 18.8856 13.0314C18.8708 13.7796 18.7287 14.5198 18.4656 15.2204C17.9953 16.4281 17.0397 17.383 15.8316 17.8524C15.1319 18.1146 14.3927 18.2563 13.6456 18.2714C12.6906 18.3264 12.3776 18.3264 9.93164 18.3264ZM9.89764 1.87341C7.45164 1.87341 7.19764 1.88541 6.24264 1.92841C5.67263 1.93596 5.10812 2.04115 4.57364 2.23941C3.78439 2.54141 3.15987 3.1634 2.85464 3.95141C2.65485 4.4917 2.54965 5.06238 2.54364 5.63841C2.49064 6.60741 2.49064 6.86141 2.49064 9.29041C2.49064 11.6904 2.49964 11.9814 2.54364 12.9444C2.55259 13.5146 2.65774 14.0792 2.85464 14.6144C3.16032 15.4019 3.78473 16.0234 4.57364 16.3254C5.10776 16.525 5.67249 16.6302 6.24264 16.6364C7.21064 16.6924 7.46564 16.6924 9.89764 16.6924C12.3506 16.6924 12.6046 16.6804 13.5516 16.6364C14.122 16.6295 14.687 16.5243 15.2216 16.3254C16.0061 16.0208 16.6266 15.4007 16.9316 14.6164C17.131 14.0757 17.2362 13.5047 17.2426 12.9284H17.2536C17.2966 11.9724 17.2966 11.7174 17.2966 9.27441C17.2966 6.83141 17.2856 6.57441 17.2426 5.61941C17.2337 5.04986 17.1285 4.48592 16.9316 3.95141C16.6273 3.16598 16.0067 2.5447 15.2216 2.23941C14.6871 2.04015 14.1221 1.93493 13.5516 1.92841C12.5846 1.87341 12.3316 1.87341 9.89764 1.87341ZM9.93164 13.9094C8.06163 13.9106 6.37506 12.7851 5.6585 11.0579C4.94195 9.33058 5.33655 7.34174 6.65827 6.01887C7.98 4.696 9.9685 4.29968 11.6964 5.01474C13.4243 5.7298 14.5512 7.41539 14.5516 9.28541C14.5489 11.8365 12.4827 13.9044 9.93164 13.9094ZM9.93164 6.28341C8.27479 6.28341 6.93164 7.62655 6.93164 9.28341C6.93164 10.9403 8.27479 12.2834 9.93164 12.2834C11.5885 12.2834 12.9316 10.9403 12.9316 9.28341C12.9278 7.62815 11.5869 6.28725 9.93164 6.28341ZM14.7316 5.57041C14.1371 5.5682 13.6565 5.08499 13.6576 4.49041C13.6587 3.89583 14.1411 3.41441 14.7356 3.41441C15.3302 3.41441 15.8125 3.89583 15.8136 4.49041C15.8139 4.77727 15.6999 5.05243 15.4969 5.25508C15.2939 5.45774 15.0185 5.5712 14.7316 5.57041Z"
                fill="white"
              />
            </svg>
          </span>
          <span>
            <svg
              width="22"
              height="18"
              viewBox="0 0 22 18"
              fill="none"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path
                id="coolicon"
                d="M19.3959 2.9696C20.2923 2.43369 20.9631 1.58984 21.2829 0.595605C20.4405 1.09541 19.5189 1.44748 18.5579 1.6366C17.2255 0.227132 15.1144 -0.115869 13.4043 0.799261C11.6942 1.71439 10.8084 3.66109 11.2419 5.5516C7.7915 5.37838 4.57686 3.74852 2.39789 1.0676C1.26073 3.02903 1.84185 5.53639 3.72589 6.7976C3.0446 6.7757 2.37842 6.59124 1.78289 6.2596C1.78289 6.27761 1.78289 6.2956 1.78289 6.3136C1.78329 8.35676 3.22327 10.1167 5.22589 10.5216C4.59396 10.6935 3.9311 10.7188 3.28789 10.5956C3.85109 12.3429 5.46145 13.5399 7.29689 13.5756C5.77673 14.7687 3.89937 15.4158 1.96689 15.4126C1.62437 15.4131 1.2821 15.3934 0.941895 15.3536C2.90428 16.6146 5.18826 17.284 7.52089 17.2816C10.7661 17.3039 13.8849 16.0245 16.1796 13.7296C18.4743 11.4347 19.7535 8.31585 19.7309 5.0706C19.7309 4.8846 19.7266 4.6996 19.7179 4.5156C20.5583 3.90821 21.2837 3.15575 21.8599 2.29361C21.0769 2.64067 20.2464 2.86853 19.3959 2.9696Z"
                fill="white"
              />
            </svg>
          </span>
        </div>
      </div>
    </div>
  );
}
