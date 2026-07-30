import { configureStore } from "@reduxjs/toolkit";

import authReducer from "../redux/auth/authSlice";
import uiReducer from "../redux/ui/uiSlice";

export const store = configureStore({
  reducer: {
    auth: authReducer,
    ui: uiReducer,
  },
});