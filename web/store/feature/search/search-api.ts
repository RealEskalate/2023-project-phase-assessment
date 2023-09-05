import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

const baseUrl = "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1";

export const doctor_search = createApi({
  reducerPath: "doctorslist",
  baseQuery: fetchBaseQuery({ baseUrl: baseUrl }),
  tagTypes: ["doctorslist"],
  endpoints: (builder) => ({
    getDoctors: builder.query<any, { keyword: string }>({
      query: (keyword) =>
        `search?keyword=${keyword}&institutions=false&articles=false`,
      providesTags: ["doctorslist"],
    }),
  }),
});

export const { useGetDoctorsQuery } = doctor_search;
