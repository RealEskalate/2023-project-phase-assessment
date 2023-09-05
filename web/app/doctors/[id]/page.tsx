import { FaSearch, FaPhone, FaMailchimp } from 'react-icons/fa';
import {Doctor} from "@/type/doctor/doctor";


const DoctorDetail = async ({params}: { params: { id: string } })=>{

    const responseData = await fetch(`https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/users/doctorProfile/${params.id}`);
    const data: Doctor = await responseData.json();

    console.log(data)
    return (
        <>
            <section className="w-10/12 font-poppins flex flex-col items-start mx-auto">
                <div className="rounded-lg w-full bg-cover bg-center flex flex-col justify-end h-60" style={{backgroundImage: "url('/images/background.png')"}}>
                    <img className="w-[150px] h-[150px] rounded-full p-1 bg-purple-700 shadow-lg shadow-purple-400 -mb-20  mx-auto" src={data.photo} />
                </div>

                <div className="m-auto w-8/12 mt-32 flex flex-col gap-14">
                    <div className="flex flex-col gap-2">
                        <div className="flex justify-between w-full">
                            <h2 className="font-bold text-[1.3rem]">
                                {data.fullName}
                            </h2>
                            <h6 className="font-light text-[0.9rem]">
                                {data.institutionID_list.length > 0? data.institutionID_list[0].institutionName: ""}
                            </h6>
                        </div>
                        <div className="flex justify-between w-full">
                            <h5 className="font-semibold text-[1rem]" >
                                {data.speciality.length > 1? data.speciality[0].name: ""}
                            </h5>
                            <h4 className="font-light text-[0.9rem]">
                                {data.institutionID_list.length > 1? data.institutionID_list[1].institutionName: ""}
                            </h4>
                        </div>
                    </div>

                    <div className="flex flex-col items-start gap-6">
                        <h2 className="font-semibold text-[1rem]" >
                            About
                        </h2>
                        <p className="font-light">
                            { data.summary.length > 1? data.summary: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis pellentesque purus sit amet mi aliquam, id dictum augue vulputate. Pellentesque porta, ligula non pulvinar sollicitudin, dolor nunc molestie dui, sit amet volutpat eros nibh vitae magna. Nullam tempor, purus nec rutrum varius, arcu massa scelerisque diam, nec vestibulum diam neque a massa. Mauris tempor odio in ornare cursus. Maecenas in ultricies sapien. Suspendisse dolor turpis, pretium vitae lacus eget, condimentum aliquam diam."}
                        </p>
                    </div>

                    <div className="flex flex-col gap-6">
                        <h2 className="font-semibold text-[1rem]" >
                            Education
                        </h2>
                        {
                            data.education.map(
                                (edu)=>{
                                    return (
                                        <div className="flex justify-between">
                                            <div className="flex flex-col items-start">
                                                <h2 className="font-semibold text-[1rem]" >
                                                    Addis Ababa University
                                                </h2>
                                                <h4>
                                                    B.Sc Medicine
                                                </h4>
                                            </div>

                                            <p>
                                                2003-2007
                                            </p>
                                        </div>
                                    )
                                }
                            )
                        }

                    </div>

                    <div className="flex-col flex gap-6">
                        <h2>
                            Contact Info
                        </h2>

                        <div className="flex flex-col">

                            <div className="flex gap-1">
                                <FaPhone/>
                                <h3 className="text-purple-500 font-bold text-[1rem]" >
                                    Phone Number:
                                </h3>
                            </div>
                            <p>
                                +251-823-323-232
                            </p>

                        </div>

                        <div className="flex flex-col">

                            <div className="flex gap-1">
                                <FaMailchimp />
                                <h3 className=" text-purple-500 font-semibold text-[1rem]" >
                                    Email:
                                </h3>
                            </div>
                            <p>
                                leulabay1@gmail.com
                            </p>

                        </div>
                    </div>
                </div>
            </section>
        </>
    )
}

export default DoctorDetail