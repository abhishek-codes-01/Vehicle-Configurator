import api from './axiosConfig';

const authService = {
  login: async (credentials) => {
    const response = await api.post('/api/auth/login', credentials);
    return response.data;
  },

  register: async (userData) => {
    const response = await api.post('/api/auth/register', userData);
    return response.data;
  },

  refreshToken: async () => {
    const response = await api.post('/api/auth/refresh');
    return response.data;
  },

  logout: async () => {
    const response = await api.post('/api/auth/logout');
    return response.data;
  }
};

export default authService;