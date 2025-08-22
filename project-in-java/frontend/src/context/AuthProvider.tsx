import React, { createContext, useContext, useState, useEffect } from "react";
import authService from "../service/authService";

interface User {
  username: string;
  role?: string;
  email?: string;
}

interface AuthContextType {
  user: User | null;
  login: (credentials: { username: string; password: string }) => Promise<{ success: boolean; error?: string }>;
  logout: () => void;
  isAuthenticated: () => boolean;
  loading: boolean;
}

const AuthContext = createContext<AuthContextType | null>(null);

export const AuthProvider = ({ children }: { children: React.ReactNode }) => {
  const [user, setUser] = useState<User | null>(null);
  const [loading, setLoading] = useState(false);

  // Check for existing token on app startup
  useEffect(() => {
    const token = sessionStorage.getItem("token");
    const savedUser = sessionStorage.getItem("user");
    
    console.log("AuthProvider init - Token:", token ? "exists" : "missing");
    console.log("AuthProvider init - User:", savedUser ? "exists" : "missing");
    
    if (token && savedUser) {
      try {
        setUser(JSON.parse(savedUser));
        console.log("✅ User restored from sessionStorage");
      } catch (error) {
        console.error("❌ Error parsing saved user:", error);
        sessionStorage.removeItem("token");
        sessionStorage.removeItem("user");
      }
    }
  }, []);

  const login = async ({ username, password }: { username: string; password: string }) => {
    try {
      setLoading(true);
      console.log("🔐 Login attempt for:", username);
      
      const response = await authService.login({ username, password });
      console.log("📥 Login response:", response);
      
      // Backend returns { token, refreshtoken }
      const { token, refreshtoken } = response;
      
      if (!token) {
        throw new Error("No access token received from server");
      }

      // Store the token
      sessionStorage.setItem("token", token);
      console.log("✅ Token stored successfully");

      // Create and store user object
      const userData: User = {
        username: username,
        role: "USER"
      };

      sessionStorage.setItem("user", JSON.stringify(userData));
      setUser(userData);
      console.log("✅ User data stored:", userData);
      
      return { success: true };
    } catch (error: any) {
      console.error("❌ Login error:", error);
      
      // Clear any existing auth data
      sessionStorage.removeItem("token");
      sessionStorage.removeItem("user");
      setUser(null);
      
      let errorMessage = "Login failed";
      if (error.response?.data) {
        // Handle different response formats
        if (typeof error.response.data === 'string') {
          try {
            const parsed = JSON.parse(error.response.data);
            errorMessage = parsed.error || "Login failed";
          } catch {
            errorMessage = error.response.data;
          }
        } else if (error.response.data.error) {
          errorMessage = error.response.data.error;
        }
      } else if (error.response?.status === 401) {
        errorMessage = "Invalid username or password";
      } else if (error.message) {
        errorMessage = error.message;
      }
      
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
      sessionStorage.removeItem("token");
      sessionStorage.removeItem("user");
      setUser(null);
      console.log("👋 User logged out");
    }
  };

  const isAuthenticated = (): boolean => {
    const token = sessionStorage.getItem("token");
    const hasUser = user !== null;
    console.log("🔍 isAuthenticated check - Token:", token ? "exists" : "missing", "User:", hasUser);
    return !!(token && hasUser);
  };

  return (
    <AuthContext.Provider value={{ user, login, logout, isAuthenticated, loading }}>
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
