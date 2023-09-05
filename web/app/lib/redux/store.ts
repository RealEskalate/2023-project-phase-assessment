/* Core */
import { configureStore } from '@reduxjs/toolkit';
import { docsApi } from './slice/doctors-slice';
/* Instruments */


export const store = configureStore({
  reducer: {
    [docsApi.reducerPath]: docsApi.reducer,
  },
    middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(docsApi.middleware),
});


export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
