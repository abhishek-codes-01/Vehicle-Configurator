// authService.js
import api from "./axiosConfig";

const authService = {
  login: async (credentials) => {
    const response = await api.post("/api/auth/login", credentials);

    if (response.data?.token) {
      sessionStorage.setItem("token", response.data.token);
    }

    return response.data;
  },

  logout: () => {
    sessionStorage.removeItem("token");
    sessionStorage.removeItem("user");
  },
};

export default authService;
