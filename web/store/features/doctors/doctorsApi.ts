import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { Doctor } from "@/types/Doctor";
import { Response } from '@/types/Response';

const BASE_URL = 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1'

export const doctorsApi = createApi({
  reducerPath: 'doctorApi',
  baseQuery: fetchBaseQuery({
    baseUrl: BASE_URL,
    // prepareHeaders: (headers, { getState }) => {
    //   const userData = localStorage.getItem('user')
    //   const token = userData ? JSON.parse(userData)?.token : null
    //   if(token) {
    //     headers.set('Authorization', `Bearer ${token}`)
    //   }
    //   return headers
    // }
  }),
  endpoints: (builder) => ({
    
    getDoctors: builder.query<any, void>({
      query: () => ({
        url: '/search?institutions=false&articles=False',
        method: 'POST',
        // body: {
        //   institutions: false,
        //   articles: false,
        // },
      }),
    }),
    getSingleDoctor: builder.query<any, any>({
      query: (id) => `/users/doctorProfile/${id}`,
    })
  }),
});

export const { useGetDoctorsQuery, useGetSingleDoctorQuery } = doctorsApi;