import React from 'react';

const Footer = () => {
  return (
    <footer className="bg-Sub-Primary py-8 px-4 grid grid-cols-3 grid-rows-2">
      <div className="text-white ">
        <h3 className="text-xl font-bold mb-4">Hakim Hub</h3>
        <p className="mb-2">Copyright © 2023 Hakim Hub</p>
        <p>Privacy Policy</p>
      </div>
      <div className="flex-1 pl-4 ">
        <h3 className="text-xl font-bold text-white mb-4">Get Connected</h3>
        <ul className="mb-4">
          <li>
            <a href="#"></a>
          </li>
          <li>
            <a href="#"></a>
          </li>
          <li>
            <a href="#"></a>
          </li>
        </ul>
        <h3 className="text-xl font-bold text-white mb-4">Action</h3>
        <ul className="mb-4">
          <li>
            <a href="#"></a>
          </li>
          <li>
            <a href="#"></a>
          </li>
        </ul>
        <h3 className="text-xl font-bold text-white mb-4">Company</h3>
        <ul>
          <li>
            <a href="#"></a>
          </li>
          <li>
            <a href="#"></a>
          </li>
        </ul>
      </div>
    </footer>
  );
};

export default Footer;