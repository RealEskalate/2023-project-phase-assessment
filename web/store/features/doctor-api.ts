import { doctorDetail } from "@/types/doctor-detail.model";
import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
const Url = "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1";
//hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/
https: export const doctorApi = createApi({
  reducerPath: "doctorApi",
  baseQuery: fetchBaseQuery({
    baseUrl: Url,
  }),
  endpoints: (build) => ({
    getDoctorDetails: build.query<doctorDetail, string>({
      query: (id) => `/users/doctorProfile/${id}`,
    }),
    getAllDoctors: build.mutation<{ find: any; page: any }, doctorDetail[]>({
      query: (find: any, page: any) =>
        `/search=${find}?institutions=false&from=${page}&size=8`,
    }),
  }),
});

export const { useGetDoctorDetailsQuery, useGetAllDoctorsMutation } = doctorApi;
