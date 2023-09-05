import { configureStore } from "@reduxjs/toolkit";
import { doctorsAPI } from "./feature/doctor/doctors-api";
import { singleDoctorAPI } from "./feature/doctor-profile/doctor-profile";
import { doctor_search } from "./feature/search/search-api";

export const store = configureStore({
  reducer: {
    [doctorsAPI.reducerPath]: doctorsAPI.reducer,
    [singleDoctorAPI.reducerPath]: singleDoctorAPI.reducer,
    [doctor_search.reducerPath]: doctor_search.reducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware()
      .concat(doctorsAPI.middleware)
      .concat(singleDoctorAPI.middleware)
      .concat(doctor_search.middleware)
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
