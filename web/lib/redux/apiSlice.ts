import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const api = createApi({
  baseQuery: fetchBaseQuery({
    baseUrl: "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/",
  }),
  endpoints: (build) => ({
    getDoctorById: build.query({
      query: (id) => `users/doctorProfile/${id}`,
    }),
    getDoctors: build.mutation({
      query: () => ({
        url: `search?institutions=false&articles=False`,
        method: "POST",
        body: {},
      }),
    }),
    getDoctorsPaginated: build.mutation({
      query: ({ from = 1, size = 8 }) => ({
        url: `search?institutions=false&from=${from}&size=${size}`,
        method: "POST",
        body: {},
      }),
    }),
    search: build.mutation({
      query: (keyword) => ({
        url: `search?keyword=${keyword}&institutions=false&articles=False`,
        method: "POST",
        body: {},
      }),
    }),
  }),
});

export const {
  useGetDoctorByIdQuery,
  useGetDoctorsPaginatedMutation,
  useGetDoctorsMutation,
  useSearchMutation,
} = api;
