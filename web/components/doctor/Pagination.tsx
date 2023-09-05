

interface PaginationProps {
    num: number
    goToPage: (pageNumber: number) => void;
    page: number
}

const Pagination: React.FC<PaginationProps> = ({num, goToPage, page})=> {
        return <button key={num} onClick={()=>goToPage(num+1)} className={(page==num+1)? "bg-primary text-white rounded-lg border-none w-[40px] h-[40px]":"bg-gray-300 text-black rounded-lg border-none w-[40px] h-[40px]"}>
            {num+1}
        </button>
}

export default Pagination