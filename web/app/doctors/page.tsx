'use client'

import React, { useState } from 'react';
import { useFetchAllDoctorsQuery, useFetchDoctorsWithPaginationQuery, useSearchDoctorsQuery } from '@/store/features/doctors/doctors-api';
import DoctorCard from '@/components/card/DoctorCard';
import SearchBar from '@/components/searchBar/SearchBar';
import { Doctor } from '@/types/doctor';
import Loading from '@/components/common/Loading';
import Link from 'next/link';
import ReactPaginate from 'react-paginate';



const DoctorsListPage = () => {
  const [query, setQuery] = useState('');
  const { data: allDoctorsData, isLoading: isAllDoctorsLoading, isError: isAllDoctorsError } = useFetchAllDoctorsQuery();
  const { data: filteredData, isLoading: isSearchLoading, isError: isSearchError } = useSearchDoctorsQuery({ keyword: query });
  const [currentPage, setCurrentPage] = useState(1);
  const { data, isLoading, isError } = useFetchDoctorsWithPaginationQuery({
    from: currentPage,
    size: 8,
  });


  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setQuery(e.target.value);
  };


  const renderDoctorCards = () => {
    if (isAllDoctorsLoading || isSearchLoading) {
      return <Loading />;
    }

    if (isAllDoctorsError || isSearchError) {
      return <div>Error fetching doctors.</div>;
    }

    console.log("doctors",allDoctorsData)
    console.log("filterd",filteredData)
    if (query.length === 0) {
      if (allDoctorsData) {
        return (
          
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 mt-16 py-5 px-12 gap-4">
            {allDoctorsData.data.map((doctor) => (
              <Link href={`/doctors/${doctor._id}`}>
                <DoctorCard key={doctor._id} doctor={doctor} />
              </Link>
            ))}
          </div>
          
        );
      } else {
        return <div className='flex justify-center'>No results found.</div>;
      }
    } else if (filteredData && filteredData.data.length > 0) {
      return (
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
          {filteredData.data.map((doctor:Doctor) => (
            <Link href={`/doctors/${doctor._id}`}>
              <DoctorCard key={doctor._id} doctor={doctor} />
            </Link>
          ))}
        </div>
      );
    } else {
      return <div className=' flex justify-center'>No results found for your search.</div>;
    }
  };
  return (
    <div className='mt-10'>
      <SearchBar handleInputChange={handleInputChange} />
      {renderDoctorCards()}
      
    </div>
  );
};

export default DoctorsListPage;

