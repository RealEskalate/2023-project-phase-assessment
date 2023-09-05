import {createApi,fetchBaseQuery } from '@reduxjs/toolkit/query/react'

const authApi = createApi({
    reducerPath: 'doctors-api',
    baseQuery:fetchBaseQuery({baseUrl:'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/'}),
    endpoints: (build)=>({
        getDoctors:build.mutation({
            query:((user:User)=>({
                url:'search?institutions=false&articles=False',
                method:'Post',
            }))
        }),
        getDoctorById:build.mutation({
            query:((id:string)=>({
                url:`doctors/${id}`,
                method:'Get'
            }))
        }),
        getDoctorBySpeciality:build.mutation({
            query:((speciality:string)=>({
                url:`search?institutions=false&articles=False&speciality=${speciality}`,
                method:'Get'
            }))
        }),
        getDoctorByInstitution:build.mutation({
            query:((institution:string)=>({
                url:`search?institutions=false&articles=False&institution=${institution}`,
                method:'Get'
            }))
        }),

    })
})


export const {useGetDoctorsMutation,useGetDoctorByIdMutation,useGetDoctorBySpecialityMutation,useGetDoctorByInstitutionMutation} = doctorsApi

export default doctorsApi

// Path: 2023-project-phase-assessment/web/store/features/doctors/doctors-api.ts

                
