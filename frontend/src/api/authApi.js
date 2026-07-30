import api from "./axios";

export const login = (credentials) => {
  return api.post("/auth/login", credentials);
};

export const logout = () => {
  return api.post("/auth/logout");
};

export const refreshToken = () => {
  return api.post("/auth/refresh-token");
};

export const getCurrentUser = () => {
  return api.get("/auth/me");
};