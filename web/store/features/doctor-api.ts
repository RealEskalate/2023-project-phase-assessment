import { doctorDetail } from "@/types/doctor-detail.model";
import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
const Url = "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1";

https: export const doctorApi = createApi({
  reducerPath: "doctorApi",
  baseQuery: fetchBaseQuery({
    baseUrl: Url,
  }),
  endpoints: (build) => ({
    getDoctorDetails: build.query<doctorDetail, string>({
      query: (id) => `/users/doctorProfile/${id}`,
    }),
    getAllDoctors: build.mutation< doctorDetail[],{ find: any; page: any }>({
      query: (find: any, page: any) =>
        
        ({
            url: `/search=${find}?institutions=false&from=${page}&size=8`, 
            method: 'POST',
    }),
  }),
});
})

export const { useGetDoctorDetailsQuery, useGetAllDoctorsMutation } = doctorApi;
