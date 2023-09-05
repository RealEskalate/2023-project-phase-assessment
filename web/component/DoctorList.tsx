import { useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import {
  fetchDoctorDetailById,
  fetchDoctorsList,
  setCardData,
} from "../Reducer/createSlice";
import { RootState } from "@/Reducer/store";
import { useGetDoctorsQuery } from "@/Reducer/doctorAi";

const DoctorList = () => {
  const { data, isLoading, error } = useGetDoctorsQuery();
  if (isLoading) return <div>Loading...</div>;
  return (
    <div>
      <input
        type="text"
        placeholder="Name"
        className="p-2 h-50 mt-165 ml-228 border border-gray-300 rounded-42 ml-10"
        style={{
          borderRadius: "42px",
          borderWidth: "1px",
          position: "relative",
          width: 1006,
        }}
      />
      <ul>
        {data.data.map((doctor) => (
          <li key={doctor.id}>
            <h2>{doctor.fullName}</h2>
            <p>{doctor.specialty}</p>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default DoctorList;
