'use client'
import { useState, useEffect } from "react";
// import { getDoctors } from "../store/doctorSlice";
import {useDispatch, useSelector} from 'react-redux';

const DoctorsList=()=>{
const [doctors, getDoctors]= useState([])
useEffect(()=>{
    //fetching api 
    fetch('https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/search?institutions=false&articles=FalseMethod - POST')
    .then(data=>data.json())
    .then(result=>getDoctors(doctors:result))
 },[])

return(
    <>
    <input 
        className='w-9/12 rounded-full border-2 h-12 ml-28 my-7 text-xl text-search p-2 pl-7 flex justify-between'
        placeholder='Name'
       />
    
    {JSON.stringify(doctors)}
    {/* creating cards */}
    <div className="shadow-lg shadow-[#0f0e23] w-80 h-56 rounded-2xl text-center border-t-none	">
        <div className="rounded-full w-24 h-24 border-2	border-[#6C63FF] mb-30 mx-28"></div>
        <p className="text-lg font-semibold mt-30	">Dr. Ziad Ali</p>
        <div className="p-1 rounded-3xl h-8 bg-[#6C63FF] w-32 mx-24">Orthopedician</div>
        <p className="text-[#686868] text-sm m-2 font-normal	">Washington Medical Center | MCM korean Hospital</p>
        

    </div>
    </>
)

};
export default DoctorsList;