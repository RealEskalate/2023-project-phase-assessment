import { configureStore, getDefaultMiddleware } from "@reduxjs/toolkit";
import { doctorsApi } from "./slices/doctorsApi";

const store = configureStore({
  reducer: {
    [doctorsApi.reducerPath]: doctorsApi.reducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(doctorsApi.middleware),
});

export default store;
