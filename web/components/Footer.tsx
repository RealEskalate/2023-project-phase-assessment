import React from 'react';

const Footer = () => {
  return (
    <footer className="bg-sub-primary text-white font-poppins justify-between p-12 mt-24">
      <div className='flex justify-between'>
        <h3 className="text-xl font-bold mb-4">Hakim Hub</h3>
        <div className="flex gap-16">
          <div>
            <h3 className="text-xl font-bold mb-4">Get Connected</h3>
            <ul className="mb-4">
              <li>
                <a href="#">For Physicians</a>
              </li>
              <li>
                <a href="#">For Hospitals</a>
              </li>
            </ul>
          </div>

          <div>
            <h3 className="text-xl font-bold mb-4">Action</h3>
            <ul className="mb-4">
              <li>
                <a href="#">Find a doctor</a>
              </li>
              <li>
                <a href="#">Find a hospital</a>
              </li>
            </ul>
          </div>

          <div>
            <h3 className="text-xl font-bold mb-4">Company</h3>
            <ul>
              <li>
                <a href="#">About us</a>
              </li>
              <li>
                <a href="#">Contact us</a>
              </li>
              <li>
                <a href="#">Join our team</a>
              </li>
            </ul>
          </div>
        </div>
      </div>

      <div className="flex gap-6 mt-10">
        <p>Privacy Policy</p>
        <p>Terms of use</p>
      </div>
    </footer>
  );
};

export default Footer;