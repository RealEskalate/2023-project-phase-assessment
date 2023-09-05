import { doctorDetail } from "@/types/doctor-detail.model";
import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
const Url = "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1";
export const doctorApi = createApi({
  reducerPath: "doctorApi",
  baseQuery: fetchBaseQuery({
    baseUrl: Url,
  }),
  endpoints: (build) => ({
    getDoctorDetails: build.query<doctorDetail, string>({
      query: (id) => `/users/doctorProfile/${id}`,
    }),
  }),
});

export const { useGetDoctorDetailsQuery } = doctorApi;
