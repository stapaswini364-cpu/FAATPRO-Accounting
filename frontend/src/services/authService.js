import api from "../api/axios";

const login = async (email, password) => {
  const response = await api.post("/auth/login", {
    email,
    password,
  });

  return response.data;
};

const logout = () => {
  localStorage.removeItem("token");

  localStorage.removeItem("user");
};

const authService = {
  login,

  logout,
};

export default authService;
