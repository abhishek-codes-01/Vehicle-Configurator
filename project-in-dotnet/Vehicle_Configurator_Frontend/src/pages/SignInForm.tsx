import React, { useState } from "react";
import { useAuth } from "../context/AuthProvider.js";
import { Navigate, useLocation } from "react-router-dom";
const SignInForm: React.FC = () => {
  const [username, setUsername] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [error, setError] = useState<string>("");

  const { login, isAuthenticated, loading } = useAuth();
  const location = useLocation();

  // Redirect if already authenticated
  if (isAuthenticated()) {
    const from = (location.state as any)?.from?.pathname || "/";
    return <Navigate to={from} replace />;
  }

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    setError("");

    if (!username.trim() || !password.trim()) {
      setError("Please fill in all fields.");
      return;
    }

    const result = await login({ username, password });

    if (!result.success) {
      setError(result.error || "Username or password incorrect");
    }
  };

  return (
    <form
      onSubmit={handleSubmit}
      className="max-w-md mx-auto mt-10 p-6 bg-white rounded-lg shadow-md space-y-4"
    >
      <h2 className="text-2xl font-bold text-center mb-4">Sign In</h2>

      {error && (
        <div className="bg-red-100 border border-red-400 text-red-700 px-4 py-3 rounded">
          {error}
        </div>
      )}

      <div>
        <label className="block mb-1 font-medium">Username</label>
        <input
          type="text"
          value={username}
          onChange={(e) => setUsername(e.target.value)}
          required
          className="w-full p-2 border rounded focus:outline-none focus:border-blue-500"
          placeholder="Enter your username"
          disabled={loading}
        />
      </div>

      <div>
        <label className="block mb-1 font-medium">Password</label>
        <input
          type="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          required
          className="w-full p-2 border rounded focus:outline-none focus:border-blue-500"
          placeholder="Enter your password"
          disabled={loading}
        />
      </div>

      <div className="text-right">
        <a
          href="/forgot-password"
          className="text-blue-600 hover:underline text-sm"
        >
          Forgot Password?
        </a>
      </div>

      <button
        type="submit"
        disabled={loading}
        className={`w-full py-2 rounded text-white font-medium ${
          loading
            ? "bg-gray-400 cursor-not-allowed"
            : "bg-blue-600 hover:bg-blue-700"
        }`}
      >
        {loading ? "Signing In..." : "Sign In"}
      </button>
    </form>
  );
};

export default SignInForm;
