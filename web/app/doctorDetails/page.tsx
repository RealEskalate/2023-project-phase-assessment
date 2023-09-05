import Image from "next/image"; 
const DoctorDetail=()=>{

return(
       <main className="">
        <div>
            <Image width={1280} height={846} src='/images/manik-roy-u7GtZ0yVijw-unsplash 1.png' alt='cover'/>
        </div>
        <div className="grid grid-cols-2 w-3/5 m-4">
            <div>
                <p className="text-3xl	font-semibold	">Dr Fasil Tefera</p>
                <p className="font-light text-[#4E4E4E]">Internal Medicine</p>
            </div>
            <div className="text-xl	font-normal	text-[#686868]">
                <p className="text-lg">Addis Ababa University</p>
                <p>Washington Medical Center</p>
            </div>

        </div>
        <div className="w-3/5 m-4">
            <p className="text-lg font-bold ">About</p>
            <p className="text-[#686868] text-base	">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis pellentesque purus sit amet mi aliquam, id dictum augue vulputate. Pellentesque porta, ligula non pulvinar sollicitudin, dolor nunc molestie dui, sit amet volutpat eros nibh vitae magna. Nullam tempor, purus nec rutrum varius, arcu massa scelerisque diam, nec vestibulum diam neque a massa. Mauris tempor odio in ornare cursus. Maecenas in ultricies sapien. Suspendisse dolor turpis, pretium vitae lacus eget, condimentum aliquam diam.</p>
        </div>
        <div className="w-3/5 m-4">
            <p className="text-lg font-bold ">Education</p>
            <div className="grid grid-cols-2">
            <div>
                <p className="font-medium	text-lg	">Addis Ababa University</p>
                <p className="text-[#8C8C8C] text-lg	">B.Sc Medicine</p>
            </div>
            <div className="text-[#8C8C8C] text-lg	">2003 - 2007</div>
            </div>
            <div className="grid grid-cols-2">
            <div>
                <p className="font-medium	text-lg	">Harvard University</p>
                <p className="text-[#8C8C8C] text-lg	">M. Sc Internal Medicine</p>
            </div>
            <div className="text-[#8C8C8C] text-lg	">2007 - 2011</div>
            </div>
        </div>
        <div className="w-3/5 m-4">
            <p className="text-lg font-bold mb-2">contact info</p>
            <div >
            <div className="flex">
                <span><Image width={16} height={16} alt="socials" src='/icons/Vector (1).svg'/></span>
                <span className="mx-3">Phone Number</span>
            </div>

                <p className="mx-7">+25111763498</p>
            </div>
            <div >
            <div className="flex mt-3">
                <span><Image width={16} height={16} alt="socials" src='/icons/Vector (2).svg'/></span>
                <span className="mx-3">Email</span>
            </div>

                <p className="mx-7">fasiltefera@stpaul.com</p>
            </div>
        </div>
       </main>
)

};
export default DoctorDetail;