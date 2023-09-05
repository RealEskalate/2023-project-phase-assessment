import { createApi, fetchBaseQuery} from "@reduxjs/toolkit/query/react";
import {Doctor} from "@/type/doctor/doctor";

interface DoctorsResponse {
    success: boolean,
    message: string,
    totalCount: number,
    data: Doctor[],
}


export const doctorsApi = createApi({
    reducerPath: "doctorsApi",
    baseQuery: fetchBaseQuery({baseUrl: "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/"}),
    tagTypes: ["doctors"],
    endpoints: (builder)=>({
        getDoctors: builder.query<DoctorsResponse,{institutions:boolean, articles:boolean} >({
            query: (queryParams) => ({
                url:"search",
                method: "POST",
                params:queryParams,
            })
        }),
        searchDoctors: builder.query<DoctorsResponse,{keyword:string,institutions:boolean, articles:boolean, from: number, size: number} >({
            query: (queryParams) => ({
                url:"search",
                method: "POST",
                params:queryParams,
            })
        })
    }),
})

export const { useGetDoctorsQuery, useSearchDoctorsQuery} = doctorsApi;