import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { Doctor } from "@/types/doctors/doctor";

const baseUrl = "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1";

export const searchDoctorsApi = createApi({
  reducerPath: "searchDoctorsPath",
  baseQuery: fetchBaseQuery({
    baseUrl: baseUrl,
  }),
  tagTypes: ["search-doctors"],
  endpoints: (builder) => ({
    getSearchResult: builder.query<Doctor, string>({
      query: (keyword) => ({
        url: `/search`,
        method: "POST",
        params: {
            keyword: keyword,
            institutions: false,
            articles: false,
        }
      }),
      providesTags: ['search-doctors']
    }),
  }),
});

export const {useGetSearchResultQuery} = searchDoctorsApi;