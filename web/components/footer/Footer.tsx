import { AiOutlineInstagram, AiOutlineTwitter } from 'react-icons/ai'
import { MdFacebook } from "react-icons/md"
import { BiLogoLinkedin } from 'react-icons/bi'


const Footer: React.FC = () => {

    return (
        <div className='fixed bottom-0 left-0 right-0 mb-0 mt-20 flex flex-col bg-primary  w-screen px-20 pt-20'>
            <div className='flex fle-row justify-between items-start font-poppins border-white text-white border-b pb-15'>
                <div className='font-bold text-3xl '>HakimHub</div>
                <div className='flex flex-row gap-[70px] first-letter: '>
                    <div className='flex flex-col justify-start items-center gap-3'>
                        <div className="font-bold text-[16px]">Get Connected</div>
                        <div className="text-[16px]">For Physicians</div>
                        <div className="text-[16px]">For Hospitals</div>
                    </div>
                    <div className='flex flex-col justify-start items-center gap-3'>
                        <div className="font-bold text-[16px]">Actions</div>
                        <div className="text-[16px]">Find a Doctor</div>
                        <div className="text-[16px]">Find a Hospital</div>
                    </div>
                    
                    <div className='flex flex-col justify-start items-center gap-3'>
                        <div className="font-bold text-[16px]">Company</div>
                        <div className="text-[16px]">About Us</div>
                        <div className="text-[16px]">Career</div>
                        <div className="text-[16px]">Join Our Team</div>
                    </div>
                    
                </div>
            </div>

            <div className='flex fle-row justify-between items-center'>

                <div className='flex-1 flex flex-row gap-5 my-5 text-white'>
                    <div className='text-[16px] font-semibold'>Privacy Policy</div>
                    <div className='text-[16px] font-semibold'>Terms of service</div>
                </div>

                <div className='flex-1 flex flex-row justify-between items-center text-white'>
                    <MdFacebook />
                    <AiOutlineInstagram />
                    <BiLogoLinkedin />
                    <AiOutlineTwitter />

                </div>

            </div>

        </div>
    )
}

export default Footer