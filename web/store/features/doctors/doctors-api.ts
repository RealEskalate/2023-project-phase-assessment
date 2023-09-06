import {createApi,fetchBaseQuery } from '@reduxjs/toolkit/query/react'

const doctorsApi = createApi({
    reducerPath: 'doctors-api',
    baseQuery:fetchBaseQuery({baseUrl:'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/'}),
    endpoints: (build)=>({
        getDoctors:build.query({
            query:()=>({
                url:'search?institutions=false&articles=False',
                method:'POST',
                body:{}
            })
        }),
        getDoctorById:build.query({
            query:((id:string)=>({
                url:`users/doctorProfile/${id}`,
                method:'GET',
            }))
        }),
        filterByKeyword:build.query({
            query:((keyword:string)=>({
                url:`search?keyword=${keyword}&institutions=false&articles=False`,
                method:'POST',
                body:{}
            }))
        }),



    })
})

export const {useGetDoctorsQuery,useGetDoctorByIdQuery, useFilterByKeywordQuery} = doctorsApi
export default doctorsApi

               
// https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/search?keyword=abe&institutions=false&articles=False