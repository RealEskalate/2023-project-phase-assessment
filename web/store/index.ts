import { configureStore } from "@reduxjs/toolkit";
import { doctorsApi } from "./features/doctors/doctors-api";
import { searchDoctorsApi } from "./features/search_doctor/search-doctor-api";
import { doctorProfileApi } from "./features/profile/doctor-profile-id-api";

export const store = configureStore({
  reducer: {
    [doctorsApi.reducerPath]: doctorsApi.reducer,
    [searchDoctorsApi.reducerPath]: searchDoctorsApi.reducer,
    [doctorProfileApi.reducerPath]: doctorProfileApi.reducer,
  },
  middleware: getDefaultMiddleware => getDefaultMiddleware().concat(doctorsApi.middleware).concat(searchDoctorsApi.middleware).concat(doctorProfileApi.middleware)
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
