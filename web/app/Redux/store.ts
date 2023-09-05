"use client"

import { configureStore } from '@reduxjs/toolkit'
import { hakimApi } from './hakimApi'

export const store = configureStore({
  reducer: {
    [hakimApi.reducerPath]: hakimApi.reducer
  },
  middleware: (getDefaultMiddleware) => 
    getDefaultMiddleware().concat(hakimApi.middleware)  
})
