import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

const BASE_URL: string = "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/" 
type PostType = {
    id: string;
    body: string;
    userId: number;
    title: string;
  };

export const docsApi = createApi({
  reducerPath : 'docs',
  baseQuery: fetchBaseQuery({ baseUrl: BASE_URL }),
  endpoints: (builder) => ({
    getAllDocs: builder.mutation({
        query: () => ({
            url: 'search?institutions=false&articles=False',
            method: 'POST',
        }),
    }),
    getDetailDoc: builder.query({
        query: (id) => ({ url: `users/doctorProfile/${id}`}),
    }),
    searchDoc: builder.mutation({
        query: (name) => ({
            url: `search?${name? "keyword="+name+"&" : ""}institutions=false&articles=False`,
            method: 'POST',
            body: {},
        }),
    }),
  }),
});


export const { useGetAllDocsMutation, useGetDetailDocQuery, useSearchDocMutation } = docsApi;
