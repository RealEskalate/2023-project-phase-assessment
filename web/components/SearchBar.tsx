import React from 'react'
import {FaSearch} from 'react-icons/fa'

const SearchBar = () => {
  return (
    <div className="relative max-w-lg mx-auto mt-24">
      <input
        type="text"
        placeholder="Name"
        className="text-gray-500 w-full py-2 px-4 rounded-full border border-gray-300 focus:outline-none pl-6"
      />
      <div className="absolute inset-y-0 right-6 flex items-center pl-3 pointer-events-none">
        <FaSearch className="text-gray-400" />
      </div>
    </div>
  )
}

export default SearchBar