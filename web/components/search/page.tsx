import { useGetDoctorsQuery } from "@/store/feature/doctor/doctors-api";
import Image from "next/image";
import Link from "next/link";
import React, { useState } from "react";
import Card from "../card/page";

const Search = () => {
  const [val, setval] = useState<string>("");
  const { data, isLoading, isError } = useGetDoctorsQuery("keyword");

  const [searchValue, setSearchValue] = useState<string>("");

  const handleSearch = () => {
    setval(searchValue);
    // Call the API or perform any other action with the search value
  };

  if (!data) {
    return <p> Not searchfound</p>;
  }

  if (isLoading) {
    return <p>Loading</p>;
  } else
    return (
      <>
        <div className="w-8/12 flex mx-auto outline outline-searchColor rounded-full justify-around items-center p-3 my-3">
          <input
            className="w-10/12 outline-none rounded-full text-xl text-gray-600"
            type="search"
            value={searchValue}
            onChange={(e) => setSearchValue(e.target.value)}
            placeholder="Name"
          />

          <Image
            onClick={handleSearch}
            src={"search-icon.svg"}
            width={1}
            height={5}
            alt="link arrow image"
            className="w-8 h-8 mr-2 rounded-full cursor-pointer"
          />
        </div>

        <div className=" m-5  w-10/12 mx-auto  flex justify-around  flex-wrap ">
          {data?.data.map((doctor) => (
            <Link
              href={`/doctor/${doctor._id}`}
              key={doctor._id}
              className=" md:w-[22%] my-5 cursor-pointer "
            >
              <Card doctorItem={doctor} />
            </Link>
          ))}
        </div>
      </>
    );
};

export default Search;
