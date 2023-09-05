import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { Doctor } from "@/types/doctors/doctor";

const baseUrl = "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1";
export const doctorsApi = createApi({
  reducerPath: "doctorsPath",
  baseQuery: fetchBaseQuery({
    baseUrl: baseUrl,
  }),
  tagTypes: ["doctors"],
  endpoints: (builder) => ({
    getDoctors: builder.query<Doctor, void>({
      query: () => ({
        url: "/search?institutions=false&articles=False",
        method: "POST",
      }),
      providesTags: ['doctors']
    }),
  }),
});

export const {useGetDoctorsQuery} = doctorsApi;