
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

export const hakimApi = createApi({
  reducerPath: 'hakimApi',
  baseQuery: fetchBaseQuery({ baseUrl: 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app'}),
  endpoints: (builder) => ({
    getHakims: builder.query({
      
      query: () => ({
        url: '/api/v1/search',
        method: 'POST',
        body: {
          institutions: false,
          articles: false
        }
      }) 
    }),
    getHakimsPaginated: builder.query({
      query: ({page, size}) => `/api/v1/search?from=${page}&size=${size}` 
    }),
    getHakimDetails: builder.query({
      query: (id) => ({url: `/api/v1/users/doctorProfile/${id}`})
    }),
    searchHakims: builder.mutation({
      query: (term) => ({
        url: `/api/v1/search?keyword=${term}&institutions=false&articles=False`,
        method: 'POST',
        body: {
          keyword: term
        }
      })
    })
  })
})

export const { 
  useGetHakimsQuery,
  useGetHakimsPaginatedQuery,
  useGetHakimDetailsQuery,
  useSearchHakimsMutation 
} = hakimApi