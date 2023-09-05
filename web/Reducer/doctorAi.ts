import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
const doctorApi = createApi({
  reducerPath: "doctorApi",
  baseQuery: fetchBaseQuery({
    baseUrl: "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/",
  }),
  endpoints: (builder) => ({
    getDoctors: builder.query<any, void>({
      query: () => `/search?institutions=false&articles=False`,
    }),
    getDoctorDetail: builder.query<any, string>({
      query: (id) => `//users/doctorProfile/${id}`,
    }),
  }),
});
export const { useGetDoctorsQuery, useGetDoctorDetailQuery } = doctorApi;
export default doctorApi;
