import React, { createContext, useContext, useState, useEffect } from "react";
import authService from "../service/authService";

interface User {
  username: string;
  role?: string;
  email?: string;
}

interface AuthContextType {
  user: User | null;
  login: (credentials: {
    username: string;
    password: string;
  }) => Promise<{ success: boolean; error?: string }>;
  logout: () => void;
  isAuthenticated: () => boolean;
  loading: boolean;
}

const AuthContext = createContext<AuthContextType | null>(null);

export const AuthProvider = ({ children }: { children: React.ReactNode }) => {
  const [user, setUser] = useState<User | null>(null);
  const [loading, setLoading] = useState(false);

  // Restore session from storage
  useEffect(() => {
    const token = sessionStorage.getItem("accessToken");
    const savedUser = sessionStorage.getItem("user");

    if (token && savedUser) {
      try {
        setUser(JSON.parse(savedUser));
        console.log("✅ User restored from sessionStorage");
      } catch (error) {
        console.error("❌ Error parsing saved user:", error);
        sessionStorage.clear();
      }
    }
  }, []);

  const login = async ({
    username,
    password,
  }: {
    username: string;
    password: string;
  }) => {
    try {
      setLoading(true);
      const response = await authService.login({ username, password });

      // Expecting backend to send accessToken and email in response
      const { token, email } = response; // <-- change this line
      if (!token) {
        throw new Error("No access token received from server");
      }
      sessionStorage.setItem("token", token);

      // Save user data including email
      const userData: User = { username, email, role: "USER" };
      sessionStorage.setItem("user", JSON.stringify(userData));
      setUser(userData);

      return { success: true };
    } catch (error: any) {
      sessionStorage.clear();
      setUser(null);

      let errorMessage = "Login failed";
      if (error.response?.data?.error) errorMessage = error.response.data.error;
      else if (error.response?.data)
        errorMessage =
          typeof error.response.data === "string"
            ? error.response.data
            : JSON.stringify(error.response.data);
      else if (error.message) errorMessage = error.message;

      return { success: false, error: errorMessage };
    } finally {
      setLoading(false);
    }
  };

  const logout = async () => {
    try {
      await authService.logout();
    } catch (error) {
      console.error("Logout error:", error);
    } finally {
      sessionStorage.clear();
      setUser(null);
    }
  };

  const isAuthenticated = (): boolean => {
    return !!(sessionStorage.getItem("token") && user);
  };

  return (
    <AuthContext.Provider
      value={{ user, login, logout, isAuthenticated, loading }}
    >
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => {
  const context = useContext(AuthContext);
  if (!context) {
    throw new Error("useAuth must be used within an AuthProvider");
  }
  return context;
};
