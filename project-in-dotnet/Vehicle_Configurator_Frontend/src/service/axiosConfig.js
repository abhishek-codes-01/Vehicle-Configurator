// axiosConfig.js
import axios from "axios";

const api = axios.create({
  baseURL: "https://localhost:7027", // Your backend URL
});

// Add Authorization header dynamically
api.interceptors.request.use(
  (config) => {
    const token = sessionStorage.getItem("token");
    if (token) {
      config.headers["Authorization"] = `Bearer ${token}`;
    }
    return config;
  },
  (error) => Promise.reject(error)
);

export default api;
