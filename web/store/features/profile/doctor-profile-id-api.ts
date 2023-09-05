import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { Doctor,DoctorInfo } from "@/types/doctors/doctor";

const baseUrl = "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/users/doctorProfile";
export const doctorProfileApi = createApi({
  reducerPath: "doctorProfilePath",
  baseQuery: fetchBaseQuery({
    baseUrl: baseUrl,
  }),
  tagTypes: ["doctorProfile"],
  endpoints: (builder) => ({
    getDoctor: builder.query<DoctorInfo, string>({
      query: (id) => ({
        url: `/${id}`,
        method: "GET",
      }),
      providesTags: ['doctorProfile']
    }),
  }),
});

export const {useGetDoctorQuery} = doctorProfileApi;