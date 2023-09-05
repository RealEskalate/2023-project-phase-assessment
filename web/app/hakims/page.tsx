"use client"
import React, { useState } from 'react';
import { BsSearch } from 'react-icons/bs';
import { useGetHakimsQuery, useSearchHakimsMutation } from "../Redux/hakimApi";
import HakimCard from "@/components/HakimCard";
import Link from "next/link";
import PaginationButtons from "@/components/PaginationButtons";

export default function HakimsPage() {
  const [searchTerm, setSearchTerm] = useState('');
  const [searchResults, setSearchResults] = useState([]);
  const [searchHakims, {isLoading:isSearching, error : searchError}] = useSearchHakimsMutation();
  const { data: allData, error: fetchDataError, isLoading: isFetchingData } = useGetHakimsQuery();

  const handleSearch = async(e) => {
    console.log("change")
    setSearchTerm(e.target.value);
    let val = await searchHakims(searchTerm)
    setSearchResults(val.data );
    console.log(val, "here")
  };

  if (isFetchingData) return <p>Loading...</p>;
  if (fetchDataError) return <p>Error fetching hakims</p>;

  return (
    <div className="bg-white">
      <div className="bg-white text-xl relative flex w-3/4 mx-auto rounded-full h-14 outline-none border border-gray-300 ">
        <input
          type="text"
          placeholder="Name"
          className="w-full px-4 py-3 pr-10 text-sm rounded-full outline-none"
          value={searchTerm}
          onChange={handleSearch}
        />

        <div className="absolute right-0 top-1/2 transform -translate-y-1/2 pr-5">
          <BsSearch size={20} className="text-gray-600" />
        </div>
      </div>

      {searchTerm !== '' && (
        <>
        {console.log(searchResults)}
          {isSearching ? (
            <p>Loading search results...</p>
          ) : searchError ? (
            <p>Error searching hakims: {searchError.message}</p>
          ) : (
            searchResults?.data?.map((hakim) => (
              <div key={hakim._id}>
                <div className="grid grid-cols-4 gap-5">
                  {hakim?.doctors?.map((doctor) => (
                    <Link href={`hakims/${doctor._id}`} key={doctor._id}>
                      <HakimCard
                        _id={doctor._id}
                        name={doctor.fullName}
                        image={doctor.photo}
                        specialization="Internal doctor"
                        institutionName={hakim.institutionName}
                      />
                    </Link>
                  ))}
                </div>
              </div>
            ))
          )}
        </>
      )}

      {searchTerm === '' && (
        <>
          {allData?.data.map((hakim) => (
            <div key={hakim._id}>
              <div className="grid grid-cols-4 gap-5">
                {hakim.doctors.map((doctor) => (
                  <Link href={`hakims/${doctor._id}`} key={doctor._id}>
                    <HakimCard
                      _id={doctor._id}
                      name={doctor.fullName}
                      image={doctor.photo}
                      specialization="Internal doctor"
                      institutionName={hakim.institutionName}
                    />
                  </Link>
                ))}
              </div>
            </div>
          ))}
          <PaginationButtons />
        </>
      )}
    </div>
  );
}