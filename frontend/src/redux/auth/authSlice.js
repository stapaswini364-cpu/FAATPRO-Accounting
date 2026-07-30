import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  user: JSON.parse(localStorage.getItem("user")) || null,

  token: localStorage.getItem("token") || null,

  isAuthenticated: !!localStorage.getItem("token"),

  loading: false,

  error: null,
};

const authSlice = createSlice({
  name: "auth",

  initialState,

  reducers: {
    loginStart: (state) => {
      state.loading = true;

      state.error = null;
    },

    loginSuccess: (state, action) => {
      const { user, token } = action.payload;

      state.user = user;

      state.token = token;

      state.isAuthenticated = true;

      state.loading = false;

      localStorage.setItem("token", token);

      localStorage.setItem("user", JSON.stringify(user));
    },

    loginFailure: (state, action) => {
      state.loading = false;

      state.error = action.payload;
    },

    logout: (state) => {
      state.user = null;

      state.token = null;

      state.isAuthenticated = false;

      localStorage.removeItem("token");

      localStorage.removeItem("user");
    },
  },
});

export const {
  loginStart,

  loginSuccess,

  loginFailure,

  logout,
} = authSlice.actions;

export default authSlice.reducer;
