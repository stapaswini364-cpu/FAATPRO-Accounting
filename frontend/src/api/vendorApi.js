import api from "./axios";

// Get all vendors
export const getVendors = () => {
  return api.get("/vendors");
};

// Get vendor by ID
export const getVendorById = (id) => {
  return api.get(`/vendors/${id}`);
};

// Create vendor
export const createVendor = (data) => {
  return api.post("/vendors", data);
};

// Update vendor
export const updateVendor = (id, data) => {
  return api.put(`/vendors/${id}`, data);
};

// Delete vendor
export const deleteVendor = (id) => {
  return api.delete(`/vendors/${id}`);
};