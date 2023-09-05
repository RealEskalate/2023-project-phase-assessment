import { configureStore } from "@reduxjs/toolkit";
import doctorApi from "./services/doctorApi";
import doctorSlice from "./features/doctorSlice";
const store = configureStore({
  reducer: {
    [doctorApi.reducerPath]: doctorApi.reducer,
    doctors: doctorSlice,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(doctorApi.middleware),
});
export type RootState = ReturnType<typeof store.getState>;
export const selectState: any = (state: RootState) => state.doctors.doctors;
export default store;
