// src/axiosConfig.js
import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:8081',
});

// Add Authorization header interceptor
api.interceptors.request.use(
  (config) => {
    const token = sessionStorage.getItem('token'); // or localStorage
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    } else {
      console.warn('No token found in sessionStorage');
    }
    return config;
  },
  (error) => Promise.reject(error)
);

// No redirect on 403
api.interceptors.response.use(
  (response) => response,
  (error) => {
    if (error.response?.status === 403) {
      console.warn("Forbidden request – user might not be logged in.");
    }
    return Promise.reject(error);
  }
);

export default api;
