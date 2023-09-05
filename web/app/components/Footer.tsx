import Image from "next/image"; 
const Footer=()=>{

return(
    <footer>
        <div className="grid grid-cols-2 bg-[#7879F1] h-60 w-full ">
            <div className="text-[#fff] text-3xl font-bold p-6">
                HAKIMHUB
            </div>
            <div className="grid grid-cols-3 p-6">
                <div>
                    <p className="text-[#fff] text-base font-bold p-3">Get Connected</p>
                    <div className="flex px-3 py-1">
                    <span className="my-2">
                        <Image
                            width={7}
                            height={7}
                            src="/icons/coolicon.svg"
                            alt="ptr"
                        />
                    </span>
                    <span className="font-light	text-base text-[#fff]"> For Physicians</span>
                    </div>
                    <div className="flex px-3 py-1">
                    <span className="my-2">
                        <Image
                            width={7}
                            height={7}
                            src="/icons/coolicon.svg"
                            alt="ptr"
                        />
                    </span>
                    <span className="font-light	text-base text-[#fff]"> For Hospitals</span>
                    </div>
                </div>
                <div>
                    <p className="text-[#fff] text-base font-bold p-3">Actions</p>
                    <div className="flex px-3 py-1">
                    <span className="my-2">
                        <Image
                            width={7}
                            height={7}
                            src="/icons/coolicon.svg"
                            alt="ptr"
                        />
                    </span>
                    <span className="font-light	text-base text-[#fff]"> Find Hospital</span>
                    </div>
                    <div className="flex px-3 py-1">
                    <span className="my-2">
                        <Image
                            width={7}
                            height={7}
                            src="/icons/coolicon.svg"
                            alt="ptr"
                        />
                    </span>
                    <span className="font-light	text-base text-[#fff]"> Find Doctors</span>
                    </div>
                </div>
                <div>
                    <p className="text-[#fff] text-base font-bold m-3">Get Connected</p>
                    <div className="flex px-3 py-1">
                    <span className="my-2">
                        <Image
                            width={7}
                            height={7}
                            src="/icons/coolicon.svg"
                            alt="ptr"
                        />
                    </span>
                    <span className="font-light	text-base text-[#fff]"> About us</span>
                    </div>
                    <div className="flex px-3 py-1">
                    <span className="my-2">
                        <Image
                            width={7}
                            height={7}
                            src="/icons/coolicon.svg"
                            alt="ptr"
                        />
                    </span>
                    <span className="font-light	text-base text-[#fff]"> Careers</span>
                    </div>
                    <div className="flex px-3 py-1">
                    <span className="my-2">
                        <Image
                            width={7}
                            height={7}
                            src="/icons/coolicon.svg"
                            alt="ptr"
                        />
                    </span>
                    <span className="font-light	text-base text-[#fff]"> Join the Team</span>
                    </div>
                </div>
            </div>
           <hr className=""/>
           <hr className="w-1/2"/>
           <div className="grid grid-cols-3 m-4">
                <div>
                    <p className="text-[#fff] text-base font-bold">Privacy Policy</p>
                </div>    
                <div>
                    <p className="text-[#fff] text-base font-bold">Terms of Use</p>
                </div>  
            </div>
            <></>
            <div className="flex my-4 mx-12">
               <Image width={20} height={20} alt="socials" src="/icons/coolicon (1).svg" px-12/>
                <Image width={20} height={20} alt="socials" src="/icons/coolicon (2).svg" mx-12/>
                <Image width={20} height={20} alt="socials" src="/icons/coolicon (3).svg" mx-12/>
               <Image width={20} height={20} alt="socials" src="/icons/coolicon (4).svg" p-4/>
            </div>
        </div>

    </footer>
)

};
export default Footer;