import Image from "next/image"; 
const Header=()=>{

return(
    <nav className="flex inline ">
        <div className="flex inline">
            <div>
             <Image
                src='/images/Frame.svg'
                width={90}
                height={90}
                alt="hakimhub logo"
             />   
            </div>
            <div className="leading-3 my-8">
            <span className="text-[#424242] text-3xl	font-bold	">HAKIM</span>
            <span className="text-[#FF7272] text-3xl	font-bold	">HUB</span>
            </div>

        </div>
        <div className="flex inline ml-80"></div>
        <div className="flex inline ml-96">
            <div className="my-4 mx-3"> 
             <Image
                src='/images/Ellipse 26.svg'
                width={68}
                height={68}
                alt="avatar"
             />   
            </div>
            <div className="leading-6 my-9 mx-3">
            
            <span className="text-[#5A5555] text-base font-normal">Jonathan Alemayehu</span>
            </div>
            <div className="leading-6 my-11 mx-3">
             <Image
                src='/icons/Mask.svg'
                height={20}
                width={20}
                alt="hakimhub logo"
             />   
            </div>

        </div>
    </nav>    
)

};
export default Header;