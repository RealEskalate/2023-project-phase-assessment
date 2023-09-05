import React from 'react';
import { Doctor } from '@/types/doctor';

interface Props {
  doctor: Doctor;
}

const DoctorCard: React.FC<Props> = ({ doctor }) => {
  return (
    <div className="bg-white rounded-xl shadow-2xl p-4">
      <div className="flex flex-col items-center">
        <div className="rounded-full overflow-hidden mb-2 bg-gray-200 w-20 h-20">
          <img
            src={doctor.photo}
            alt={doctor.fullName}
            className="w-full h-full object-cover"
          />
        </div>
        <div className='font-bold mb-2'>{doctor.fullName}</div>
        <div className='bg-bg-primary text-white rounded-full px-3 py-0.5 text-sm '>{doctor.speciality.map((speciality) => (speciality.name)).join(',')}</div>
        <div className="mt-8 mb-4">{doctor.institutionID_list.map((insitution) => (insitution.lang.am.institutionName)).join(' | ')}</div>
      </div>
    </div>
  );
};

export default DoctorCard;
