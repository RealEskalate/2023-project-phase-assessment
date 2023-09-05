'use client'
import React, { useEffect, useState } from 'react'
import DoctorCard from './components/DoctorCard';
import SerarchBar from './components/SerarchBar';
import { useGetAllDocsMutation, useSearchDocMutation } from './lib/redux/slice/doctors-slice';
import Link from 'next/link';
import SeachIcon from '@/assets/Images/SearchIcon.png';
import Image from 'next/image';
import { DotWave } from '@uiball/loaders'
import { Pagination } from './components/Pagination';

const DoctorList = () => {
    const [getDocs, docsInfo]  = useGetAllDocsMutation({});
    const [searchDocs, searchDocsInfo] = useSearchDocMutation({});
    const [allDocs, setAllDocs] = useState([])
    const [searchString, setSearchString] = useState("")

    const [page, setPage] = useState<number>(1);
    const [listPerPage, setListsPerPage] = useState(3); // Dynamic number of blogs per page
    const [paginationCount, setPaginationCount] = useState(5);

    const totalList = allDocs.length; // Calculate total number of blogs

    const startIndex = (page - 1) * listPerPage;
    const endIndex = startIndex + listPerPage;
    const paginatedList = allDocs.slice(startIndex, endIndex);

    useEffect(()=>{
        const docList = async ()=>{
            const res = await getDocs({});
            console.log(res)
            setAllDocs(res?.data.data)
            console.log(allDocs)
        }    
        docList()
    },[])

    const SearchDoc = async(e)=>{
        e.preventDefault()
        console.log("hereeeee")
        const res = await searchDocs(searchString);
        console.log(res)
        setAllDocs(res?.data.data)
        console.log(allDocs)
    }

    const updateString = async(e)=>{
        setSearchString(e.target.value)
        const res = await searchDocs(searchString);
        console.log(res)
        setAllDocs(res?.data.data)
      }
  return (
    <div className='mx-10 mt-20'>
        <div className='flex w-full justify-center mt-20'>
            <form method='post' className='flex w-full justify-center' onSubmit={SearchDoc}>
                <input onChange={updateString} value={searchString} className={`text-[#DCD0D0] rounded-full w-2/3 md:w-1/2 border-2 border-gray-200 outline-none py-3 px-8 pr-14 mb-10`} placeholder='Name'></input>
                <button className='w-10 h-10 flex items-center' type="submit">
                    <Image src={SeachIcon} alt="search Icon" className='w-6 ml-[-50px] mt-2'/>
                </button>
            </form>
        </div>
        {
            searchDocsInfo.isLoading || docsInfo.isLoading ? (
                <div className='w-full flex justify-center items-center'>
                    <div className='mt-10'>
                        <DotWave 
                            size={150}
                            speed={1} 
                            color="#7879F1"
                        />
                    </div>
                </div>
            ) : (
            allDocs.length > 0 ? 
                allDocs?.map((doc)=>{
                    return  <Link href={`/doctor-detail/${doc?._id}`}> 
                                <DoctorCard data={doc} />
                            </Link>
                })
                // <Pagination 
                :
                <h1 className='text-center text-2xl mt-10'>No Doctors Found</h1>
            )
        }
    </div>
  )
}

export default DoctorList