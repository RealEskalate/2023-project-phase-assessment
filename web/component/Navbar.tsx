"use clinet"
const Navbar = () => {
  return (
    <header className="p-4 text-white flex justify-between items-center">
      <div>
        <img src="/Component 35.png" alt="Logo" className="h-12" />
      </div>
      <div className="flex items-center space-x-1">
        <img src="/Ellipse 27.png" alt="img" className="h-12" />
        <div className="text-xl text-black">Yonatan Tesfay</div>
        <img src="/arrow-ios-down.png" alt="icon" className="h-12" />
      </div>
    
    </header>
  );
};

export default Navbar;
