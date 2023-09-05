'use client'
import React, { useEffect, useState } from 'react'
import ProfileCard from './ProfileCard'
import { useGetDoctorsMutation } from '@/app/api/apiSlice'
import { Provider } from 'react-redux'
import { store } from '@/app/store'

const DoctorsList = () => {
    const [datadocs, info] = useGetDoctorsMutation({})
    const [Doctors, setDoctors] = useState()
    console.log(datadocs);
    // useEffect(()=>{
    //     const docList = async ()=>{
    //         const res = await datadocs({});
    //         console.log(res)
    //         setDoctors(res?.data.data)
    //         console.log(Doctors)
    //     }    
    //     docList()
    // },[])
    console.log(Doctors)
  return (
    <div>
      <ProfileCard/>
    </div>
  )
}

export default DoctorsList
