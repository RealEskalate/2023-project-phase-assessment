import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { getDoctosResponse } from '@/types/doctor/getDoctosResponse';


export const doctorsApi = createApi({
  reducerPath: 'doctorsApi',
  baseQuery: fetchBaseQuery({ baseUrl: 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/' }),
  endpoints: (builder) => ({
    getAllDoctors: builder.query<getDoctosResponse, void>({
        query: () => ({
            url: 'search?institutions=false&articles=False',
            method: 'POST',
          })
    }),
    getDoctorsWithPagination: builder.query({
      query: (paginationInfo) => `search?institutions=false&from=${paginationInfo.page}&size=${paginationInfo.size}`,
    }),
    getDoctorProfile: builder.query({
      query: (id) => `users/doctorProfile/${id}`,
    }),
    searchDoctors: builder.query({
        query: (keyword) => ({
          url: 'search',
          method: 'POST',
          body: {
            keyword,
            institutions: false,
            articles: false,
          },
        }),
      }),
  }),
});

export const {
  useGetAllDoctorsQuery,
  useGetDoctorsWithPaginationQuery,
  useGetDoctorProfileQuery,
  useSearchDoctorsQuery,
} = doctorsApi;