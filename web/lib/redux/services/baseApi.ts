import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/dist/query/react";
import { RootState } from "../store";
// import { HYDRATE } from "next-redux-wrapper";

const baseApi = createApi({
  reducerPath: "baseApi",
  baseQuery: fetchBaseQuery({
    baseUrl: "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1",
  }),
//   extractRehydrationInfo(action, { reducerPath }) {
//     if (action.type === HYDRATE) {
//       return action.payload[reducerPath];
//     }
//   },
  endpoints: (builder) => ({}),
});

export default baseApi;