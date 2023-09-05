import { configureStore } from '@reduxjs/toolkit'
import { setupListeners } from '@reduxjs/toolkit/query'
import { doctorsApi } from './services/doctorsApi'

const store = configureStore({
  reducer: {
    [doctorsApi.reducerPath]: doctorsApi.reducer,
  },

  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(doctorsApi.middleware),
})
export type RootState = ReturnType<typeof store.getState>;
export default store;
setupListeners(store.dispatch)