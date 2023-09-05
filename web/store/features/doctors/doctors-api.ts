import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { Doctor, DoctorData } from '@/types/doctor'; 

const baseUrl = 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1';

export const doctorsApi = createApi({
  reducerPath: 'doctorsPath',
  baseQuery: fetchBaseQuery({
    baseUrl: baseUrl,
  }),
  tagTypes: ['doctors'],
  endpoints: (builder) => ({
    fetchAllDoctors: builder.query<DoctorData, void>({
      query: () => ({
        url: 'search',
        method: 'POST',
        params: {
          institutions: false,
          articles: false,
        },
      }),
    }),

    fetchDoctor: builder.query<Doctor, string>({
      query: (doctorId) => `users/doctorProfile/${doctorId}`,
      providesTags: ['doctors']
      
  }),

  fetchDoctorsWithPagination: builder.query({
    query: (params) => ({
      url: 'search',
      method: 'POST',
      body: {
        institutions: false,
        from: params.from,
        size: params.size,
      },
    }),
  }),

    searchDoctors: builder.query({
      query: ({ keyword }) => ({
        url: 'search',
        method: 'POST',
        params: {
          keyword,
          institutions: false,
          articles: false,
        },
      }),
    }),


  }),
});

export const { useFetchAllDoctorsQuery, useFetchDoctorsWithPaginationQuery, useSearchDoctorsQuery, useFetchDoctorQuery } = doctorsApi;
