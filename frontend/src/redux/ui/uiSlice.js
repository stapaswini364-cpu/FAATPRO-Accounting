import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  loading: false,
  darkMode: false,
};

const uiSlice = createSlice({
  name: "ui",
  initialState,
  reducers: {
    setLoading: (state, action) => {
      state.loading = action.payload;
    },

    toggleDarkMode: (state) => {
      state.darkMode = !state.darkMode;
    },
  },
});

export const { setLoading, toggleDarkMode } = uiSlice.actions;

export default uiSlice.reducer;