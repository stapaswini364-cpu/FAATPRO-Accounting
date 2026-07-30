import api from "./axios";

// Get all accounts
export const getAccounts = () => {
  return api.get("/accounts");
};

// Get account by ID
export const getAccountById = (id) => {
  return api.get(`/accounts/${id}`);
};

// Create new account
export const createAccount = (data) => {
  return api.post("/accounts", data);
};

// Update account
export const updateAccount = (id, data) => {
  return api.put(`/accounts/${id}`, data);
};

// Delete account
export const deleteAccount = (id) => {
  return api.delete(`/accounts/${id}`);
};