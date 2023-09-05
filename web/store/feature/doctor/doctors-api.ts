import { doctor } from "@/types/doctor/doctor";
import { getDoctosResponse } from "@/types/doctor/getDoctosResponse";
import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
//hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/search?institutions=false&articles=False

const baseUrl = "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1";

export const doctorsAPI = createApi({
  reducerPath: "doctors",
  baseQuery: fetchBaseQuery({ baseUrl: baseUrl }),
  tagTypes: ["doctors"],
  endpoints: (builder) => ({
    getDoctors: builder.query<getDoctosResponse, void>({
      query: () => ({
        url: "/search?institutions=false&articles=False",
        method: "POST",
      }),
      providesTags: ["doctors"],
    }),
  }),
});

export const { useGetDoctorsQuery } = doctorsAPI;
