import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { Doctor,SearchDoctorsResponse } from '@/types'

export const doctorsApi = createApi({
    reducerPath: 'doctorApi',
    baseQuery: fetchBaseQuery({ baseUrl: 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/' }),
    endpoints: (builder) => ({
      getAllDoctors: builder.query<Doctor[], {keyword:string,from:number,size:number}>({
        query: ({from,size,keyword}) => ({
            url: `search?keyword=${keyword}&institutions=false&from=${from}&size=${size}`,
            method: "POST",
          }),
      }),
      searchDoctors: builder.query<SearchDoctorsResponse, { keyword: string; page: number; pageSize: number }>({
        query: ({ keyword, page, pageSize }) => ({
          url: `search?keyword=${keyword}&institutions=false&articles=False`,
          method: 'POST',
        }),
      }),   
      getDoctorById: builder.query<Doctor,string>({
        query: (id: string) => `/users/doctorProfile/${id}`,
      }),
    }),
  })
  
  export const { useGetAllDoctorsQuery,useSearchDoctorsQuery,useGetDoctorByIdQuery} = doctorsApi;