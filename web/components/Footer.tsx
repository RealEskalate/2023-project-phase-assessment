import {AiOutlineRight} from 'react-icons/ai'
export default function Footer() {
    return (
        <footer className="  bg-[#7879F1] p-10 py-14 flex justify-between text-white">
            <span className="font-semibold text-3xl text-[#fff]">
                HakimHub
            </span>
            <div className="space-y-3">
                <p className="text-[#fff] text-xl font-bold">
                    get Connected
                </p>
                <p><AiOutlineRight className='inline-block'/> For Physicians</p>
                <p> <AiOutlineRight className='inline-block'/>For Patients</p>
            </div>
            <div className="space-y-3">
                <p className="text-[#fff] text-xl font-bold">
                    Action
                </p>
                <p><AiOutlineRight className='inline-block'/> Find a doctor</p>
                <p> <AiOutlineRight className='inline-block'/>Find a hospital</p>
            </div>
            <div className="space-y-3">
                <p className="text-[#fff] text-xl font-bold">
                    About
                </p>
                <p> <AiOutlineRight className='inline-block'/> Our Team</p>
                <p><AiOutlineRight className='inline-block'/> Our Mission</p>
            </div>
        </footer>
    )
}