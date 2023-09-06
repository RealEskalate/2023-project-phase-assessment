import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

const BASE_URL = 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1';

export const doctorsApi = createApi({
  reducerPath: 'doctorsApi',
  baseQuery: fetchBaseQuery({ baseUrl: BASE_URL }),
  endpoints: (builder) => ({
    getDoctors: builder.query({
      query: () => ({
        url: '/search?institutions=false&articles=false',
        method: 'POST',
      }),
    }),
    getSingleDoctor: builder.query({
      query: (id) => ({
        url: `/users/doctorProfile/${id}`,
        method: 'GET',
      }),
    }),
    searchDoctors: builder.query({
      query: (keyword) => ({
        url: `/search?keyword=${keyword}&institutions=false&articles=false`,
        method: 'POST',
      }),
    }),
  }),
});

export const { useGetDoctorsQuery, useGetSingleDoctorQuery, useSearchDoctorsQuery } = doctorsApi;
