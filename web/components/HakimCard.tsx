import React from 'react';
import Image from 'next/image';

const HakimCard = ({_id, name, image,specialization, institutionName}) => {

  return (
    <div key={_id} className="w-[320px] h-[300px] bg-white rounded-lg shadow-lg mt-10">

      <div className="w-24 h-24 pt-2 mx-auto ">
        <Image 
          src={image}
          alt="hakim picture"
          width={80}
          height={80}
          objectFit='cover'
          className="rounded-full w-24 h-24 border-2 border-purple-800" 
        />

      </div>

      <div className="p-4">
      
        <h3 className="text-lg font-medium text-center">{name}</h3>

        <p className="bg-purple-800 text-white px-3 py-1 w-max mx-auto my-2 rounded-full text-sm font-medium">
          {specialization}
        </p>

        <p className="text-gray-500 text-center text-sm pt-3">
          {institutionName}
        </p>
      
      </div>

    </div>
  );
}

export default HakimCard;