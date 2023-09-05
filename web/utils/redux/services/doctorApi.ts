import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

const doctorApi = createApi({
  reducerPath: "doctorApi",
  baseQuery: fetchBaseQuery({
    baseUrl: "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1",
  }),
  endpoints: (builder) => ({
    getDoctors: builder.query({
      query: () => ({
        url: "search?institutions=false&articles=False",
        method: "POST",
        timeout: 3000,
      }),
    }),
    searchDoctors: builder.mutation({
      query: (search_query: string) => ({
        url: `search?keyword=${search_query}&institutions=false&articles=False`,
        method: "POST",
        timeout: 3000,
      }),
      transformResponse: (response: any) => {
        return response;
      },
    }),

    getDoctorDetail: builder.query<any, string>({
      query: (id: string) => ({
        url: `users/doctorProfile/${id}`,
        timeout: 3000,
        method: "GET",
      }),
    }),
    getDoctorsWithPagination: builder.mutation({
      query: ({ page, size }: { page: number; size: number }) => ({
        url: `search?institutions=false&articles=False&from=${page}&size=${size}`,
        method: "POST",
        timeout: 3000,
      }),
    }),
  }),
});

export const {
  useGetDoctorsQuery,
  useSearchDoctorsMutation,
  useGetDoctorDetailQuery,
  useGetDoctorsWithPaginationMutation,
} = doctorApi;

export default doctorApi;
