const Footer = ()=>{

    const baseURL = "/images";


    let socialMedia: string[] = [
        `${baseURL}/facebook.png`,
        `${baseURL}/linkedin.png`,
        `${baseURL}/instagram.png`,
        `${baseURL}/twitter.png`,
        `${baseURL}/youtube.png`,
    ];
    return (
        <div className="flex flex-col text-white font-poppins p-8 bg-primary w-full pr-28">

            <div className="flex justify-between py-10">
                <h2 className="font-poppins text-[2rem]">HakimHub</h2>
                <div className="flex gap-x-8">
                    <div className="flex flex-col items-start font-light gap-y-3">
                        <h3 className="font-semibold">Get Connected</h3>
                        <p className="flex">For physicians </p>
                        <p className="flex">For hospitals </p>
                    </div>
                    <div className="flex flex-col items-start font-light gap-y-3">
                        <h3 className="font-semibold">Get Connected</h3>
                        <p className="flex">Find a doctor </p>
                        <p className="flex">Find a hospital </p>
                    </div>
                    <div className="flex flex-col items-start font-light gap-y-3">
                        <h3 className="font-semibold">Get Connected</h3>
                        <p className="flex">About us </p>
                        <p className="flex">Career </p>
                        <p className="flex">Join our team </p>
                    </div>
                </div>
            </div>
            <div className="flex justify-between pt-10 border-t-[1.2px] border-gray-100">
                <div className="flex gap-x-4 text-[1.2rem] font-semibold">
                    <h2>
                        Privacy Use
                    </h2>
                    <h2>
                        Terms of Use
                    </h2>
                </div>
                <div className="flex gap-5 justify-center items-end md:justify-end ">
                    {socialMedia.map((link: string, i) => {
                        return (
                            <a href="http://www.fb.com" key={i}>
                                <img className="w-[20px] h-[20px]" src={link} />
                            </a>
                        );
                    })}
                </div>
            </div>
        </div>
    )
}

export default Footer;