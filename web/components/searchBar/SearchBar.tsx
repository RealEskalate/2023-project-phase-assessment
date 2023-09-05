import React from 'react';
import { FaSearch } from 'react-icons/fa'; 
interface Props {
  handleInputChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
}

const SearchBar: React.FC<Props> = ({ handleInputChange }) => {
  return (
    <div className="doctor-search max-w-screen-xl mx-auto p-4 text-center">
      <div className="search-bar w-full md:w-2/3 mx-auto relative">
        <input
          type="text"
          placeholder="Name"
          onChange={handleInputChange}
          className="w-full py-2 px-4 border border-gray-300 rounded-full focus:outline-none focus:border-blue-500 pl-10" // Add pl-10 to make space for the icon
        />
        <div className="absolute inset-y-0 right-5 pl-3 flex items-center pointer-events-none">
          <FaSearch className="text-gray-400" /> 
        </div>
      </div>
    </div>
  );
};

export default SearchBar;
