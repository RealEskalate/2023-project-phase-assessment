import { createApi,fetchBaseQuery } from '@reduxjs/toolkit/query/react'

export const COUNT_ON_SINGLE_PAGE = 8

export const doctorsApi = createApi({
    reducerPath: "api",
    baseQuery: fetchBaseQuery({baseUrl:'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/'}),
    endpoints: (builder)=>({
        getDoctors: builder.mutation({
            query:()=>({
                url:'search',
                method:"POST",
                params: {
                    institutions:false,
                    articles:false
                }
            })
        }),
        getDoctorsWithPage: builder.mutation({
            query:(pageNumber:number)=>({
                url: 'search',
                method: 'POST',
                params: {
                    institutions:false,
                    from: pageNumber,
                    size: COUNT_ON_SINGLE_PAGE
                }
            })
        }),
        getSingleDoctor: builder.query({
            query:(id:string)=>({
                url: `/users/doctorProfile/${id}`
            })
        }),
        getDoctorsByKeyword: builder.mutation({
            query:(keyword:string)=>({
                url:'search',
                method:'POST',
                params: {
                    institutions: false,
                    articles: false,
                    keyword:keyword
                }
            })
        })
    })
})

export const { useGetDoctorsMutation,useGetDoctorsWithPageMutation,useGetSingleDoctorQuery,useGetDoctorsByKeywordMutation } = doctorsApi