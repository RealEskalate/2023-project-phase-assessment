import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { url } from "inspector";

export const doctorsApi = createApi({
  reducerPath: "doctorsApi",
  baseQuery: fetchBaseQuery({
    baseUrl: "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1",
  }),
  endpoints: (builder) => ({
    getDoctors: builder.query<any, void>({
      query: () => ({
        url: "/search?institutions=false&articles=False",
        method: "POST",
      }),
    }),
    getDoctorDetail: builder.query({
      query: (id) => ({
        url: `users/doctorProfile/${id}`,
        method: "GET",
        timeout: 3000,
      }),
    }),
    getDoctorListWithPagination: builder.mutation({
      query: ({ page, size }: { page: number; size: number }) => ({
        url: `/search?institutions=false&from=${page}&size=${size}`,
        method: "POST",
      }),
    }),
  }),
});

export const {
  useGetDoctorsQuery,
  useGetDoctorDetailQuery,
  useGetDoctorListWithPaginationMutation,
} = doctorsApi;
