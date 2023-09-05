'use client'
import Image from "next/image"
import { useRouter } from "next/navigation"
import { useState } from "react"

const SearchBar = () => {
  const[searchQuery, setSearchQuery] = useState("")
  const router = useRouter()

  const onSearch=(event:React.FormEvent)=>{
    event.preventDefault()
    const encodedSearchQuery = encodeURI(searchQuery)
    router.push(`/search/?q=${encodedSearchQuery}`)

  }

  return (
    <div>
        <form onSubmit={onSearch} className="pt-4">
            <input
            value={searchQuery}
            onChange={(event)=>{setSearchQuery(event.target.value)}}
            placeholder="Name"
            className="w-[1006px] h-12 roundex-xl rounded-custom-radius border-gray-400 border-2 p-4"
            />
        </form>
        
    </div>
  )
}

export default SearchBar