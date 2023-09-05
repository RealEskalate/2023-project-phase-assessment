

const SearchBar = () => {
    return (
        <div className='w-full flex relative'>
           
            <div className='absolute mx-auto flex justify-center w-full'>
                <input name='' className='w-96 h-16 rounded-[32px] border-2 border-gray-300 outline-none pl-10 text-xl text-gray-400' placeholder='Search...' />
            </div>

        </div>
    ) 
}

    export default SearchBar