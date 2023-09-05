import baseApi from "./baseApi";
import { Doctor } from "@/types";

const blogApi = baseApi.injectEndpoints({
  endpoints: (builder) => ({
    getDoctors: builder.query<any, void>({
      query: () => ({
        url: "/search?institutions=false&articles=False",
        method: "POST",
      }),
    }),
    getDoctorById: builder.query({
      query: (id: string) => ({
        url: `/users/doctorProfile/${id}`,
        method: "GET",
      })
    }),
  }),
  overrideExisting: false,
});

export default blogApi;
