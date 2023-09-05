import { DoctorData, baseParamType, responseType } from "@/types";
import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const doctorsApi = createApi({
  reducerPath: "doctorsApi",
  baseQuery: fetchBaseQuery({
    baseUrl: "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1",
  }),
  endpoints: (builder) => ({
    getDoctors: builder.query<responseType, baseParamType>({
      query: ({ keyword, from }) => ({
        url: `/search?institutions=false&articles=False&keyword=${keyword}&from=${from}&size=16`,
        method: "POST",
      }),
    }),
    getDoctorById: builder.query<DoctorData, string>({
      query: (id) => `/users/doctorProfile/${id}`,
    }),
  }),
});

export const { useGetDoctorsQuery, useGetDoctorByIdQuery } = doctorsApi;
