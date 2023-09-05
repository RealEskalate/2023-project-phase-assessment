import { configureStore } from '@reduxjs/toolkit'
import { doctorsApi } from './features/doctorsApi'

export const store = configureStore({
  reducer: {
    [doctorsApi.reducerPath]: doctorsApi.reducer,
  },
  
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(doctorsApi.middleware),
})

/* Types */
// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<typeof store.getState>;
// Inferred type: {posts: PostsState, comments: CommentsState, users: UsersState}
export type AppDispatch = typeof store.dispatch;