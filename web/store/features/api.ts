import { Root } from "@/node_modules/postcss/lib/postcss";
import { Daum } from "@/types/doctors-list";
import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";


export const doctorsApi = createApi({
  reducerPath: "doctorsApi",
  baseQuery: fetchBaseQuery({
    baseUrl: "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app",
  }),
  endpoints: (builder:any) => ({
    getDoctors: builder.mutation({
      query: () => ({
        url: "/api/v1/search?institutions=false&articles=False",
        method: "POST",
      }),
    }),

  }),
});

export const {
    useGetDoctorsMutation,
 
} = doctorsApi;