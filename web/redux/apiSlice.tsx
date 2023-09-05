
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const api = createApi({
  baseQuery: fetchBaseQuery({ baseUrl: 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/' }),
  endpoints: (builder) => ({
    search: builder.query({
      query: (params) => ({
        url:`search?keyword=${params.keyword}&institutions=${params.institutions}&articles=${params.articles}&from=${params.start}&size=${params.size}`,
        method: 'POST',

      })
      // change the method to POST
    }),
    profile: builder.query({
        query: (params) => ({
            url: `users/doctorProfile/${params.id}`,
            method: 'GET',
        }),
    }),
  }),

});

export const { useSearchQuery, useProfileQuery } = api;
