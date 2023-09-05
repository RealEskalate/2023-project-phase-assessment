import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import doctorApi from "../services/doctorApi";
interface InitialState {
  doctors: any;
  pending?: boolean;
  error?: any;
}
const initialState: InitialState = {
  doctors: [],
  pending: false,
  error: null,
};
const doctorSlice = createSlice({
  name: "doctors",
  initialState,
  reducers: {
    setDoctors(state, action) {
      state.doctors = action.payload.data;
    },
  },
  extraReducers(builder) {
    builder.addMatcher(
      doctorApi.endpoints.getDoctors.matchFulfilled,
      (state, action) => {
        state.doctors = action.payload.data;
        state.pending = false;
      }
    );
    builder.addMatcher(
      doctorApi.endpoints.getDoctorsWithPagination.matchFulfilled,
      (state, action) => {
        state.doctors = action.payload.data;
        state.pending = false;
      }
    );
    builder.addMatcher(
      doctorApi.endpoints.searchDoctors.matchFulfilled,
      (state, action) => {
        state.doctors = action.payload.data;
        state.pending = false;
      }
    );
    builder.addMatcher(
      doctorApi.endpoints.getDoctorsWithPagination.matchPending,
      (state, action) => {
        state.pending = true;
      }
    );
    builder.addMatcher(
      doctorApi.endpoints.searchDoctors.matchPending,
      (state, action) => {
        state.pending = true;
      }
    );
    builder.addMatcher(
      doctorApi.endpoints.getDoctors.matchPending,
      (state, action) => {
        state.pending = true;
      }
    );
    builder.addMatcher(
      doctorApi.endpoints.getDoctorsWithPagination.matchRejected,
      (state, action) => {
        state.error = action.error;
      }
    );
    builder.addMatcher(
      doctorApi.endpoints.searchDoctors.matchRejected,
      (state, action) => {
        state.error = action.error;
      }
    );
    builder.addMatcher(
      doctorApi.endpoints.getDoctors.matchRejected,
      (state, action) => {
        state.error = action.error;
      }
    );
  },
});
export const { setDoctors } = doctorSlice.actions;

export default doctorSlice.reducer;
