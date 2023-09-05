// https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/users/doctorProfile/:id
import { single_Doctor } from "@/types/doctor/single-doctor";
import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

const baseUrl = "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/users";

export const singleDoctorAPI = createApi({
  reducerPath: "doctorpath",
  baseQuery: fetchBaseQuery({ baseUrl: baseUrl }),
  tagTypes: ["doctor"],
  endpoints: (builder) => ({
    getSingleDoctor: builder.query<single_Doctor, string>({
      query: (blogId) => `/doctorProfile/${blogId}`,
      providesTags: ["doctor"],
    }),
  }),
});

export const { useGetSingleDoctorQuery } = singleDoctorAPI;
