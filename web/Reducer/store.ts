import { configureStore, getDefaultMiddleware } from "@reduxjs/toolkit";
import cardListReducer from "@/Reducer/createSlice";
import doctorApi from "./doctorAi";

const store = configureStore({
  reducer: {
    [doctorApi.reducerPath]: doctorApi.reducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(doctorApi.middleware),
});
export type RootState = ReturnType<typeof store.getState>;
export default store;
