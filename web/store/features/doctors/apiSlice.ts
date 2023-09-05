import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

import { DoctorProfile } from '@/types/doctors/models';
import { ApiResponse } from '@/types/doctors/apiType';


export const api = createApi({
  baseQuery: fetchBaseQuery({ baseUrl: 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1' }),
  endpoints: (builder) => ({
    getAllDoctors: builder.query<ApiResponse, void>({
      query: () => ({
        url: `/search?institutions=false&articles=False`,
        method: 'POST',
      }),
    }),
    getSingleDoctor: builder.query<DoctorProfile, string>({
      query: (id: string) => ({
        url: `/users/doctorProfile/${ id }`,
        method: 'GET'
      })
    }),
    searchDoctors: builder.query<ApiResponse, string>({
      query: (query: string) => ({
        url: `/search?keyword=${ query }&institutions=false&articles=False`,
        method: 'POST',
      }),
    }),
  }),
});

export const {
  useGetAllDoctorsQuery,
  useGetSingleDoctorQuery,
  useSearchDoctorsQuery
} = api;