import Image from "next/image"

const NavBar = () => {
  return (
    <div className='flex lg:flex-row lg:justify-between max-w-screen px-32 mt-2 py-2 bg-white'>
        <Image src="/images/hakim-hub.svg" width={234} height={59} alt="hakim-hub logo"/>
        <div className="flex flex-row items-center gap-3">
            <Image src = "/images/jonathan-alemayehu.svg" className="rounded-full"width={68} height={68} alt=""/>
            <span className="text-center text-black">Jonathan Alemayehu </span>
            <Image src="/images/arrow-ios-down.svg" width={20} height={20} alt="arrow-down-icon"/>
        </div>
    </div>
  )
}

export default NavBar