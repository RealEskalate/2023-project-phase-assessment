import { AiOutlineInstagram, AiOutlineTwitter } from 'react-icons/ai'
import { MdFacebook } from "react-icons/md"
import { BiLogoLinkedin } from 'react-icons/bi'


const Footer: React.FC = () => {

    return (
        <div className='flex flex-col bg-primary text-white w-screen mx-20'>
            <div className='flex fle-row justify-between items-start font-poppins border-white border-b pt-15'>
                <div className='font-bold text-3xl '>HakimHUb</div>
                <div className='flex flex-row gap-[70px] first-letter: '>
                    <div className='flex flex-col justify-start items-center gap-3'>
                        <div className="font-bold text-[16px]">Get Connected</div>
                        <div className="text-[16px]">For Physicians</div>
                        <div className="text-[16px]">For Hospitals</div>
                    </div>
                    
                    <div className='flex flex-col justify-start items-center gap-3'>
                        <div className="font-bold text-[16px]">Get Connected</div>
                        <div className="text-[16px]">For Physicians</div>
                        <div className="text-[16px]">For Hospitals</div>
                    </div>
                    
                    <div className='flex flex-col justify-start items-center gap-3'>
                        <div className="font-bold text-[16px]">Get Connected</div>
                        <div className="text-[16px]">For Physicians</div>
                        <div className="text-[16px]">For Hospitals</div>
                    </div>
                </div>
            </div>

            <div className='flex fle-row justify-between items-center'>

                <div className='flex flex-row gap-5 my-5'>
                    <div className='text-[16px] font-semibold'>Privacy Policy</div>
                    <div className='text-[16px] font-semibold'>Terms of service</div>
                </div>

                <div className=''>
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