import { BiChevronLeft, BiChevronRight } from 'react-icons/bi';

const PaginationButtons = () => {
  return (
    <div className="flex items-center justify-center space-x-2 py-5">
      
      <button 
        type="button"
        className="p-2 rounded-sm bg-white border border-purple-500 text-gray-500"
      >
        <BiChevronLeft size={20} />
      </button>

      <button 
        type="button" 
        className="p-2 rounded-sm bg-white border text-gray-500"
      >
        1
      </button>
      
      <button 
        type="button"
        className="p-2 rounded-sm bg-white border border-purple-500 text-black"  
      >
        2
      </button>

      <button 
        type="button" 
        className="p-2 rounded-sm bg-white border text-gray-500"
      >
        3
      </button>
      
      <button 
        type="button" 
        className="p-2 rounded-sm bg-white border text-gray-500"
      >
        ...
      </button>

      <button 
        type="button" 
        className="p-2 rounded-sm bg-white border text-gray-500"
      >
        10
      </button>

      <button
        type="button"
        className="p-2 rounded-sm bg-white border border-purple-500 text-gray-500"  
      >
        <BiChevronRight size={20} />
      </button>

    </div>
  );
}

export default PaginationButtons;