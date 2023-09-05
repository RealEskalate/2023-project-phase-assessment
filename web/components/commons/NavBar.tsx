const NavBar = ()=>{
    return (
        <>
            <div className="flex justify-between px-5 py-4 font-poppins">
                <img src="/images/logo.png" className="w-[170px] object-contain"/>
                <div className="flex gap-2 items-center">
                    <img src="/images/avatar.png" className="w-[50px]" />
                    <h2>
                        Jonathen Alemayehu
                    </h2>
                </div>
            </div>
        </>
    )
}

export default NavBar;