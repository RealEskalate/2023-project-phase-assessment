"use client";
import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import { fetchDoctorDetail, fetchDoctors } from "../services/cardService";

interface CardListState {
  doctors: any[];
  status: string;
  error: string | null;
}

const initialState: CardListState = {
  doctors: [],
  status: "idle",
  error: null,
};

export const fetchDoctorsList = createAsyncThunk(
  "doctors/fetchDoctors",
  async (_, { rejectWithValue }) => {
    try {
      const response = await fetchDoctors();
      return response.data;
    } catch (error) {
      rejectWithValue(error);
    }
  }
);

export const fetchDoctorDetailById = createAsyncThunk(
  "doctors/fetchDoctorDetail",
  async (id: string, { rejectWithValue }) => {
    try {
      const response = await fetchDoctorDetail(id);
      return response.data;
    } catch (error) {
      return rejectWithValue(error);
    }
  }
);

const cardListSlice = createSlice({
  name: "doctors",
  initialState,
  reducers: {
    setCardData: (state, action) => {
      state.doctors = action.payload;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(fetchDoctorsList.pending, (state) => {
        state.status = "loading";
        state.error = null;
      })
      .addCase(fetchDoctorsList.fulfilled, (state, action) => {
        state.status = "succeeded";
        state.doctors = action.payload;
        state.error = null;
      })
      .addCase(fetchDoctorsList.rejected, (state, action) => {
        state.status = "failed";
      });
  },
});

export const { setCardData } = cardListSlice.actions;
export default cardListSlice.reducer;
