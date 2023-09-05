import { createApi, fetchBaseQuery} from '@reduxjs/toolkit/query/react'

export const apiSlice = createApi({
    reducerPath: 'apiSlice',
    baseQuery: fetchBaseQuery({
        baseUrl: 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/',
    }),
    tagTypes: ['Post'],
    endpoints: (builder) => ({
        getDoctors: builder.mutation({
            query: () => ({
                url: 'search?institutions=false&articles=False',
                method: 'POST',
            }),
        }),
    }),
})

export const { useGetDoctorsMutation } = apiSlice