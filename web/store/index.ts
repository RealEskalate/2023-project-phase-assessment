import { configureStore } from "@reduxjs/toolkit";
import { doctorApi } from "./features/doctor-api";


export const store = configureStore({
  reducer: {
    [doctorApi.reducerPath]: doctorApi.reducer,
    
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware()
      .concat(doctorApi.middleware),
});

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;