import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const doctorsApi = createApi({
  reducerPath: "doctorsApi",
  baseQuery: fetchBaseQuery({ baseUrl: "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1" }),
  tagTypes: ['doctors'],
  endpoints: (builder) => ({
    getDoctorById: builder.query({
      query: ({ _id }) => ({
        url: `/users/doctorProfile/${_id}`,
        method: "GET",
      })
    }),
    getDoctors: builder.query({
      query: () => ({
        url: "/search?institutions=false&articles=False",
        method: "POST",
      })
    }),
    getDoctorsWithPagination: builder.query({
      query: ({keyword, from}) => ({
        url: `/search?keyword=${keyword}&institutions=false&from=${from}&size=8`,
        method: "POST",
      })
    }),
    searchDoctors: builder.query({
      query: ({ keyword }) => ({
        url: `/search?keyword=${keyword}&institutions=false&articles=False`,
        method: "POST"
      })
    }),
  })
})

export const {
  useGetDoctorsQuery,
  useGetDoctorsWithPaginationQuery,
  useGetDoctorByIdQuery,
  useSearchDoctorsQuery,
} = doctorsApi