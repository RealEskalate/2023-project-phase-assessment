import Image from "next/image"
const Footer = () => {
  return (
    <div className="flex flex-col bg-sub-primary max-w-screen px-32 gap-4 justify-center pt-8 bg-h-[323px]">
        <div className="flex flex-row justify-between ">
            <div>
                <p className="font-bold text-3xl font-poppins">HakimHub</p>
            </div>
            <div className="flex flex-row gap-8">
              <div className="flex flex-col">
                <p className="font-poppins font-bold text-base">Get Connected</p>
                <p  className="flex flex-row gap-1 items-center"><span><Image src="/images/coolicon.svg" width={7} height={8} alt="right arrow"/></span>For Physicians</p>
                <p  className="flex flex-row gap-1 items-center"><span><Image src="/images/coolicon.svg" width={7} height={8} alt="right arrow"/></span>For Hospitals</p>
              </div>
              <div className="flex flex-col">
                <p className="font-poppins font-bold text-base">Actions</p>
                <p  className="flex flex-row gap-1 items-center"><span><Image src="/images/coolicon.svg" width={7} height={8} alt="right arrow"/></span>Find a doctor</p>
                <p  className="flex flex-row gap-1 items-center"><span><Image src="/images/coolicon.svg" width={7} height={8} alt="right arrow"/></span>Find a hospital</p>
              </div>
              <div className="flex flex-col">
                <p className="font-poppins font-bold text-base">Company</p>
                <p className="flex flex-row gap-1 items-center"><span><Image src="/images/coolicon.svg" width={7} height={8} alt="right arrow"/></span>About Us</p>
                <p className="flex fle-row gap-1 items-center"><span><Image src="/images/coolicon.svg" width={7} height={8} alt="right arrow"/></span>Career</p>
                <p className="flex flex-row gap-1 items-center"><span><Image src="/images/coolicon.svg" width={7} height={8} alt="right arrow"/></span>Join our team</p>
              </div>
            </div>
        </div>
        <hr className='h-0 border-1 border-solid border-white-500 max-w-screen top-150'/>
        <div className="flex flex-row justify-between">
           <div className="flex flex-row justfy-between">
            <p className="font-poppins font-semibold text-xl p-2">Privacy Policy</p>
            <p className="font-poppins font-semibold text-xl p-2">Terms of Use</p>
           </div>
           <div className="flex flex-row gap-12">
               <Image src="/images/face-book.svg" width={21} height={17} alt="face book icon"/>
               <Image src="/images/linkedin.svg" width={21} height={17} alt="linkedin icon"/>
               <Image src="/images/instagram.svg" width={21} height={17} alt="instagram icon"/>
               <Image src="/images/twitter.svg" width={21} height={17} alt="twitter icon"/>
           </div>
        </div>
    </div>
  )
}

export default Footer