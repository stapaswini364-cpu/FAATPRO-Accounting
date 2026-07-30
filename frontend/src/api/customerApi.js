import api from "./axios";

// Get all customers
export const getCustomers = () => {
  return api.get("/customers");
};

// Get customer by ID
export const getCustomerById = (id) => {
  return api.get(`/customers/${id}`);
};

// Create customer
export const createCustomer = (data) => {
  return api.post("/customers", data);
};

// Update customer
export const updateCustomer = (id, data) => {
  return api.put(`/customers/${id}`, data);
};

// Delete customer
export const deleteCustomer = (id) => {
  return api.delete(`/customers/${id}`);
};